//select2 绑定数据,树形下拉选择
$.fn.bindSelect = function (options) {
    var defaults = {
        id: "id",
        text: "text",
        search: false,
        url: "",
        param: [],
        change: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);

    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            dataType: "json",
            success: function (data) {
                $element.empty();//清空下拉框
                $element.append("<option value=''>&nbsp;==请选择==</option>");
                $.each($.parseJSON(data), function (i,item) {
                    $element.append("<option value='" + item.id + "'>&nbsp;" + item.text + "</option>");
                });
                //$element.select2({
                //    minimumResultsForSearch: options.search == true ? 0 : -1
                //});
                $element.on("change", function (e) {
                    if (options.change != null) {
                        options.change(data[$(this).find("option:selected").index()]);
                    }
                    $("#select2-" + $element.attr('id') + "-container").html($(this).find("option:selected").text().replace(/　　/g, ''));
                });
            }
        });
    } else {
        $element.select2({
            minimumResultsForSearch: -1
        });
    }
}

//绑定字典内容到指定的控件
function BindDictItem(ctrlName, dictTypeName) {
    var url = '/Security/ItemsDetail/FindSelectJson?itemName=' + encodeURI(dictTypeName);
    BindSelect2(ctrlName, url);
}

//绑定内容到指定的Select控件
function BindSelect2(ctrlName, url) {
    var control = $('#' + ctrlName);
    //设置Select2的处理
    control.select2({
        allowClear: true,
        minimumResultsForSearch: 0,
        height: '40px',
        placeholder:"==请选择=="
    });

    //绑定Ajax的内容
    $.getJSON(url, function (data) {
        control.empty();//清空下拉框
        control.append("<option value=''>&nbsp;==请选择==</option>");
        $.each($.parseJSON(data), function (i, item) {
            control.append("<option value='" + item.id + "'>&nbsp;" + item.text + "</option>");
        });
    });
}
// form表单收集 数据 formSerialize
$.fn.formSerialize = function (formdate) {
    var element = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $id = element.find('#' + key);
            var value = $.trim(formdate[key]).replace(/&nbsp;/g, '');
            var type = $id.attr('type');
            if ($id.hasClass("select2-hidden-accessible")) {
                type = "select";
            }
            if ($id.hasClass("select2")) {
                type = "select";
            }
            switch (type) {
                case "checkbox":
                    if (value == "true") {
                        $id.iCheck('check');
                        $id.attr("checked", 'checked');
                    } else {
                        $id.iCheck('uncheck');
                        $id.removeAttr("checked");
                    }
                    break;
                case "select":
                    $id.val(value).trigger("change");
                    break;
                default:
                    $id.val(value);
                    break;
            }
        };
        return false;
    }
    var postdata = {};
    element.find('input,select,textarea').each(function (r) {
        var $this = $(this);
        var id = $this.attr('id');
        var type = $this.attr('type');
        switch (type) {
            case "checkbox":
                postdata[id] = $this.is(":checked");
                break;
            default:
                var value = $this.val() == "" ? "&nbsp;" : $this.val();
                if (!$.request("keyValue")) {
                    value = value.replace(/&nbsp;/g, '');
                }
                postdata[id] = value;
                break;
        }
    });
    if ($('[name=__RequestVerificationToken]').length > 0) {
        postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    return postdata;
};

//from验证
$.fn.formValid = function () {
    return $(this).valid({
        errorPlacement: function (error, element) {
            element.parents('.formValue').addClass('has-error');
            element.parents('.has-error').find('i.error').remove();
            element.parents('.has-error').append('<i class="form-control-feedback fa fa-exclamation-circle error" data-placement="left" data-toggle="tooltip" title="' + error + '"></i>');
            $("[data-toggle='tooltip']").tooltip();
            if (element.parents('.input-group').hasClass('input-group')) {
                element.parents('.has-error').find('i.error').css('right', '33px')
            }
        },
        success: function (element) {
            element.parents('.has-error').find('i.error').remove();
            element.parent().removeClass('has-error');
        }
    });
}

//以指定的Json数据，初始化JStree控件
//treeName为树div名称，url为数据源地址，checkbox为是否显示复选框，loadedfunction为加载完毕的回调函数
function bindJsTree(treeName, url, checkbox, loadedfunction) {
    var control = $('#' + treeName)
    control.data('jstree', false);//清空数据，必须

    var isCheck = arguments[2] || false; //设置checkbox默认值为false
    if (isCheck) {
        //复选框树的初始化
        $.getJSON(url, function (data) {
            control.jstree({
                'plugins': ["checkbox"], //出现选择框
                'checkbox': { cascade: "", three_state: false }, //不级联
                'core': {
                    'data': data,
                    "themes": {
                        "responsive": false
                    }
                }
            }).bind('loaded.jstree', loadedfunction);
        });
    }
    else {
        //普通树列表的初始化
        $.getJSON(url, function (data) {
            control.jstree({
                'core': {
                    'data': data,
                    "themes": {
                        "responsive": false
                    }
                }
            }).bind('loaded.jstree', loadedfunction);
        });
    }
}
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}


//删除数据
function DeleteByIds(url) {
    //得到用户选择的数据的ID
    var rows = $table.bootstrapTable('getSelections');
    if (rows.length >= 1) {
        //遍历出用户选择的数据的信息，这就是用户用户选择删除的用户ID的信息
        var ids = "";   //1,2,3,4,5
        for (var i = 0; i < rows.length; i++) {
            ids += rows[i].Id + ",";
        }
        //最后去掉最后的那一个,
        ids = ids.substring(0, ids.length - 1);
        var postData = { ids: ids };
        swal({
            title: "操作提示",
            text: "您确定删除选定的记录吗？",
            icon: "warning",
            closeOnClickOutside: false,
            buttons: {
                cancel: {
                    text: "取消",
                    visible: true,
                    closeModal: true,
                },
                confirm: {
                    text: "是的，执行删除！",
                    value: "ok",
                    className: "swal-button-confirm"
                },
            }
        }).then(function (value) {
            if (value == "ok") {
                $.ajax({
                    url: url,
                    data: postData,
                    dataType: 'json',//服务器返回json格式数据
                    type: 'post',//HTTP请求类型
                    timeout: 100000,//超时时间设置为10秒；
                    success: function (data) {
                        //服务器返回响应，根据响应结果，分析是否登录成功；
                        if (data.Success) {
                            toastr.success("删除成功");
                            setTimeout(function () {
                                $table.bootstrapTable('refresh');
                            }, 1000);
                        } else {
                            toastr.warning("操作失败：" + data.ErrMsg);
                        }
                    },
                    error: function (data) {
                        toastr.warning("删除异常,请重新试试");
                    }
                });
            }
        });
    } else {
        toastr.warning("请选择你要删除的数据");
    }
}

//禁用或启用数据
function EnableByIds(tag,url) {
    var tipStr = "启用";
    if (tag == "0") {
        tipStr = "禁用";
    }
    //得到用户选择的数据的ID
    var rows = $table.bootstrapTable('getSelections');
    if (rows.length >= 1) {
        //遍历出用户选择的数据的信息，这就是用户用户选择删除的用户ID的信息
        var ids = "";   //1,2,3,4,5
        for (var i = 0; i < rows.length; i++) {
            ids += rows[i].Id + ",";
        }
        //最后去掉最后的那一个,
        ids = ids.substring(0, ids.length - 1);
        var postData = { ids: ids };
        swal({
            title: "操作提示",
            text: "您确定" + tipStr + "选定的记录吗？",
            icon: "warning",
            closeOnClickOutside: false,
            buttons: {
                cancel: {
                    text: "取消",
                    visible: true,
                    closeModal: true,
                },
                confirm: {
                    text: "是的，执行" + tipStr + "！",
                    value: "ok",
                    className: "swal-button-confirm"
                },
            }
        }).then(function (value) {
            if (value == "ok") {
                $.ajax({
                    url: url+"/SetEnabledMarkByIds?bltag=" + tag,
                    data: postData,
                    dataType: 'json',//服务器返回json格式数据
                    type: 'post',//HTTP请求类型
                    timeout: 100000,//超时时间设置为10秒；
                    success: function (data) {
                        //服务器返回响应，根据响应结果，分析是否登录成功；
                        if (data.Success) {
                            toastr.success(tipStr + "成功");
                            setTimeout(function () {
                                $table.bootstrapTable('refresh');
                            }, 1000);
                        } else {
                            toastr.warning("操作失败：" + data.ErrMsg);
                        }
                    },
                    error: function (data) {
                        toastr.warning(tipStr + "异常,请重新试试");
                    }
                });
            }
        });
    } else {
        toastr.warning("请选择你要" + tipStr + "的数据");
    }
}