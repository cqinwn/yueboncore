var remoteServiceBaseUrl = "https://localhost:44363/api/";
var appBaseUrl = "https://localhost:44339/";
var token = "";


function gettoken() {
    $.ajax({
        url:'/token/GetAccessToken',
        data: '',
        dataType: 'json',//服务器返回json格式数据
        type: 'get',//HTTP请求类型
        timeout: 10000,//超时时间设置为10秒；
        success: function (data) {
            token = data.AccessToken;
        },
        error: function (data) {
            //异常处理；
            alert(data.ErrCode);
        }
    });
}


