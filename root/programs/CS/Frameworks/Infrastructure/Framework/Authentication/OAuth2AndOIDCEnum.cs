//**********************************************************************************
//* Copyright (C) 2007,2016 Hitachi Solutions,Ltd.
//**********************************************************************************

#region Apache License
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

//**********************************************************************************
//* クラス名        ：OAuth2AndOIDCEnum
//* クラス日本語名  ：OAuth2 / OIDCで使用する列挙型クラス
//*
//* 作成者          ：生技 西野
//* 更新履歴        ：
//*
//*  日時        更新者            内容
//*  ----------  ----------------  -------------------------------------------------
//*  2019/02/06  西野 大介         新規作成
//**********************************************************************************

namespace Touryo.Infrastructure.Framework.Authentication
{
    /// <summary>OAuth2 / OIDCで使用する列挙型クラス</summary>
    public class OAuth2AndOIDCEnum
    {
        #region ResponseMode

        /// <summary>ResponseMode</summary>
        public enum ResponseMode : int
        {
            /// <summary>query</summary>
            query,

            /// <summary>fragment</summary>
            fragment,

            /// <summary>form_post</summary>
            form_post
        }

        #endregion

        #region AuthMethods

        /// <summary>AuthMethods</summary>
        public enum AuthMethods : int
        {
            /// <summary>client_secret_basic</summary>
            client_secret_basic,

            /// <summary>client_secret_post</summary>
            client_secret_post,

            /// <summary>client_secret_jwt</summary>
            client_secret_jwt,

            /// <summary>private_key_jwt</summary>
            private_key_jwt,

            /// <summary>tls_client_auth</summary>
            tls_client_auth
        }

        #endregion

        #region ClientMode

        /// <summary>ClientMode</summary>
        public enum ClientMode : int
        {
            /// <summary>normal</summary>
            normal,

            /// <summary>fapi1</summary>
            fapi1,

            /// <summary>fapi2</summary>
            fapi2
        }

        #endregion
    }
}
