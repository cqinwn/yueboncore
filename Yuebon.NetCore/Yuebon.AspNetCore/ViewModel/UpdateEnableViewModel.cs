﻿namespace Yuebon.AspNetCore.ViewModel;

/// <summary>
/// 批量更新操作传入参数，如设为禁用、有效、软删除；
/// 物理删除操作是Flag无效不用传参
/// </summary>
[Serializable]
public class UpdateEnableViewModel
{
    /// <summary>
    /// 主键Id集合
    /// </summary>
    public long[] Ids { get; set; }
    /// <summary>
    /// 有效标识，默认为1：即设为无效,0：有效
    /// </summary>
    public string Flag { get; set; }
}
