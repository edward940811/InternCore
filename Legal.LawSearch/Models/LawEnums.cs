using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawKing.Entity.Enums
{
    /// <summary>
    /// 適用性
    /// </summary>
    public enum Applicability
    {
        /// <summary>
        /// 搜尋用(表示全部包含)
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 相關
        /// </summary>
        相關 = 1,

        /// <summary>
        /// 無關
        /// </summary>
        無關 = 2,

        /// <summary>
        /// 參考
        /// </summary>
        參考 = 3,

        /// <summary>
        /// 未鑑別
        /// </summary>
        未鑑別 = 4
    }

    /// <summary>
    /// 符合性
    /// </summary>
    public enum Compliance
    {
        /// <summary>
        /// 搜尋用(表示全部包含)
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 不符
        /// </summary>
        不符 = 1,

        /// <summary>
        /// 符合
        /// </summary>
        符合 = 2,

        /// <summary>
        /// 無關
        /// </summary>
        無關 = 3,

        /// <summary>
        /// 進行中
        /// </summary>
        進行中 = 4
    }

    /// <summary>
    /// 任務狀態
    /// </summary>
    public enum MissionState
    {
        /// <summary>
        /// 搜尋用(表示全部包含)
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 鑑別中
        /// </summary>
        鑑別中 = 1,

        /// <summary>
        /// 待審核
        /// </summary>
        待審核 = 2,

        /// <summary>
        /// 已結案
        /// </summary>
        已結案 = 3,

        /// <summary>
        /// 草稿
        /// </summary>
        草稿 = 4,

        /// <summary>
        /// 退件
        /// </summary>
        退回 = 5,

        /// <summary>
        /// 逾期
        /// </summary>
        逾期 = 6,

        /// <summary>
        /// 初始
        /// </summary>
        初始 = 9
    }

    /// <summary>
    /// 包含任務
    /// </summary>
    public enum MissionInclusionIndex
    {
        /// <summary>
        /// 計畫中法條均無包含
        /// </summary>
        均無加入 = 0,

        /// <summary>
        /// 計畫中法條部分包含
        /// </summary>
        部分加入 = 1,

        /// <summary>
        /// 計畫中法條均包含
        /// </summary>
        全部加入 = 2,
    }

    /// <summary>
    /// 異動類型
    /// </summary>
    public enum ModifyType
    {
        /// <summary>
        /// 無
        /// </summary>
        無 = 0,

        /// <summary>
        /// 修訂
        /// </summary>
        修訂 = 1,

        /// <summary>
        /// 發佈
        /// </summary>
        發佈 = 2,

        /// <summary>
        /// 廢除
        /// </summary>
        廢除 = 3
    }

    /// <summary>
    /// 異動類型 (For 報表使用)
    /// </summary>
    public enum ReportModifyType
    {
        /// <summary>
        /// 無
        /// </summary>
        無 = 0,

        /// <summary>
        /// 修訂
        /// </summary>
        修訂 = 1,

        /// <summary>
        /// 發佈
        /// </summary>
        發佈 = 2,

        /// <summary>
        /// 廢除
        /// </summary>
        廢除 = 3,

        /// <summary>
        /// 不適用
        /// </summary>
        不適用 = 4
    }

    /// <summary>
    /// 不符合事項狀態
    /// </summary>
    public enum UnfitLawContentStatus
    {
        /// <summary>
        /// 搜尋用(表示全部包含)
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 已逾期
        /// </summary>
        已逾期 = 1,

        /// <summary>
        /// 進行中
        /// </summary>
        進行中 = 2,

        /// <summary>
        /// 已結案
        /// </summary>
        已結案 = 3
    }

    /// <summary>
    /// 標籤類別
    /// </summary>
    public enum TagType
    {
        /// <summary>
        /// 清單
        /// </summary>
        共享清單 = 0,

        /// <summary>
        /// 我的最愛
        /// </summary>
        我的最愛 = 1
    }

    /// <summary>
    /// 通知設定類別
    /// </summary>
    public enum AlertSettingType
    {
        /// <summary>
        /// 清單
        /// </summary>
        共享清單 = 0,

        /// <summary>
        /// 我的最愛
        /// </summary>
        我的最愛 = 1
    }

    /// <summary>
    /// 法規雲版本
    /// </summary>
    public enum LegalEdition : int
    {
        /// <summary>
        /// 初階版
        /// </summary>
        初階版 = 1,

        /// <summary>
        /// 中階版
        /// </summary>
        中階版 = 2,

        /// <summary>
        /// 高階版
        /// </summary>
        高階版 = 3
    }

    /// <summary>
    /// 不符合等級
    /// </summary>
    public enum Level : int
    {
        /// <summary>
        /// 搜尋用(表示全部包含)
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 低
        /// </summary>
        低 = 1,

        /// <summary>
        /// 中
        /// </summary>
        中 = 2,

        /// <summary>
        /// 高
        /// </summary>
        高 = 3
    }

    /// <summary>
    /// 執行動作
    /// </summary>
    public enum DateAction
    {
        /// <summary>
        /// 無
        /// </summary>
        無 = 0,

        /// <summary>
        /// 新增
        /// </summary>
        新增 = 1,

        /// <summary>
        /// 更新
        /// </summary>
        更新 = 2,

        /// <summary>
        /// 刪除
        /// </summary>
        刪除 = 3,
    }

    /// <summary>
    /// 匯入動作
    /// </summary>
    public enum ImportResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        成功 = 1,

        /// <summary>
        /// 資料輸入有誤
        /// </summary>
        資料輸入有誤 = 2,

        /// <summary>
        /// 已存在於共享清單中
        /// </summary>
        已存在 = 3
    }

    /// <summary>
    /// 搜尋來源包含
    /// </summary>
    public enum SearchInclude
    {
        /// <summary>
        /// 全部
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 我的最愛
        /// </summary>
        我的最愛 = 1,

        /// <summary>
        /// 共享清單
        /// </summary>
        共享清單 = 2
    }

    /// <summary>
    /// 任務限制代碼
    /// </summary>
    public enum MissionLimitCode
    {
        /// <summary>
        /// 無
        /// </summary>
        無 = 0,

        /// <summary>
        /// 進行中上限
        /// </summary>
        進行中上限 = 1,

        /// <summary>
        /// 總數上限
        /// </summary>
        總數上限 = 2
    }
}
