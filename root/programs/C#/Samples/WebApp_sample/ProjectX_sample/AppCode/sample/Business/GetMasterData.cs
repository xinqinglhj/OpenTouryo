﻿//**********************************************************************************
//* マスタデータ・ロード部品
//**********************************************************************************

//**********************************************************************************
//* クラス名        ：GetMasterData
//* クラス日本語名  ：マスタデータ・ロード部品
//*
//* 作成日時        ：－
//* 作成者          ：生技
//* 更新履歴        ：
//*
//*  日時        更新者            内容
//*  ----------  ----------------  -------------------------------------------------
//*  20xx/xx/xx  ＸＸ ＸＸ         ＸＸＸＸ
//*
//**********************************************************************************

// System
using System.Data;

#region OpenTouryo
// 業務フレームワーク
using Touryo.Infrastructure.Business.Business;
using Touryo.Infrastructure.Business.Common;
using Touryo.Infrastructure.Business.Dao;
using Touryo.Infrastructure.Business.Exceptions;
using Touryo.Infrastructure.Business.Presentation;
using Touryo.Infrastructure.Business.Str;
using Touryo.Infrastructure.Business.Transmission;
using Touryo.Infrastructure.Business.Util;

// フレームワーク
using Touryo.Infrastructure.Framework.Business;
using Touryo.Infrastructure.Framework.Common;
using Touryo.Infrastructure.Framework.Dao;
using Touryo.Infrastructure.Framework.Exceptions;
using Touryo.Infrastructure.Framework.Presentation;
using Touryo.Infrastructure.Framework.Transmission;
using Touryo.Infrastructure.Framework.Util;

// 部品
using Touryo.Infrastructure.Public.Db;
using Touryo.Infrastructure.Public.IO;
using Touryo.Infrastructure.Public.Log;
using Touryo.Infrastructure.Public.Str;
using Touryo.Infrastructure.Public.Util;
#endregion

namespace ProjectX_sample
{
    /// <summary>マスタデータ・ロード部品</summary>
    public class GetMasterData : MyFcBaseLogic
    {
        /// <summary>業務処理を実装</summary>
        /// <param name="parameterValue">引数クラス</param>
        private void UOC_Invoke(_3TierParameterValue parameterValue)
        { //メソッド引数にBaseParameterValueの派生の型を定義可能。

            // 戻り値クラスを生成して、事前に戻り地に設定しておく。
            _3TierReturnValue returnValue = new _3TierReturnValue();
            this.ReturnValue = returnValue;

            // ↓業務処理-----------------------------------------------------

            // データアクセス クラスを生成する
            DaoSuppliers daoSuppliers = new DaoSuppliers(this.GetDam());

            // 全件参照
            DataTable dt1 = new DataTable();
            daoSuppliers.D2_Select(dt1);

            // データアクセス クラスを生成する
            DaoCategories daoCategories = new DaoCategories(this.GetDam());

            // 実行
            DataTable dt2 = new DataTable();
            daoCategories.D2_Select(dt2);

            // 戻り値を戻す
            returnValue.Obj = new DataTable[] { dt1, dt2 };

            // ↑業務処理-----------------------------------------------------
        }
    } 
}