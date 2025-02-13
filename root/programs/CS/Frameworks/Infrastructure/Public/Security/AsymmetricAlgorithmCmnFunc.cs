﻿//**********************************************************************************
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
//* クラス名        ：RsaAndDsaCmnFunc
//* クラス日本語名  ：RsaAndDsaCmnFuncクラス
//*
//* 作成者          ：生技 西野
//* 更新履歴        ：
//*
//*  日時        更新者            内容
//*  ----------  ----------------  -------------------------------------------------
//*  2017/12/25  西野 大介         新規作成
//*  2018/11/09  西野 大介         RSAOpenSsl、DSAOpenSsl、HashAlgorithmName対応
//*  2019/01/29  西野 大介         X.509対応（JWE（RSAES-OAEP and AES GCM）対応
//**********************************************************************************

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using Touryo.Infrastructure.Public.Util;

namespace Touryo.Infrastructure.Public.Security
{
    /// <summary>
    /// AsymmetricAlgorithmCmnFuncクラス
    /// - RSACryptoServiceProvider:
    ///   MD5, SHA1, SHA256, SHA384, SHA512
    /// - DSACryptoServiceProvider:SHA1
    /// だけ、サポート。
    /// </summary>
    public class AsymmetricAlgorithmCmnFunc
    {
        #region Simple factories
        /// <summary>RsaFactory</summary>
        /// <returns>RSA</returns>
        public static RSA RsaFactory()
        {
            // ハンドリングをRSA（ベースの型に）に変更したので行けるハズ
            return RSA.Create();
        }

        /// <summary>DsaFactory</summary>
        /// <returns>DSA</returns>
        public static DSA DsaFactory()
        {
            // ハンドリングをDSA（ベースの型に）に変更したので行けるハズ
            return DSA.Create();
        }

        /// <summary>CreateSameKeySizeSP</summary>
        /// <param name="aa1">AsymmetricAlgorithm</param>
        /// <returns>AsymmetricAlgorithm(RSA or DSA)</returns>
        public static AsymmetricAlgorithm CreateSameKeySizeSP(AsymmetricAlgorithm aa1)
        {
            AsymmetricAlgorithm aa2 = (AsymmetricAlgorithm)Activator.CreateInstance(aa1.GetType());
            aa2.KeySize = aa1.KeySize;
            return aa2;
        }

        #endregion

        #region CreateCryptographySP

        /// <summary>対称アルゴリズム暗号化サービスプロバイダ生成</summary>
        /// <param name="easa">EnumASymmetricAlgorithm</param>
        /// <param name="certificateFilePath">X.509証明書(*.pfx, *.cer)へのパス</param>
        /// <param name="password">パスワード</param>
        /// <param name="flag">X509KeyStorageFlags</param>
        /// <returns>AsymmetricAlgorithm</returns>
        public static AsymmetricAlgorithm CreateCryptographySP(EnumASymmetricAlgorithm easa,
            string certificateFilePath = "", string password = "",
            X509KeyStorageFlags flag = X509KeyStorageFlags.DefaultKeySet)
        {
            AsymmetricAlgorithm asa = null;

            if (easa == EnumASymmetricAlgorithm.X509)
            {
                // X.509対応
                X509Certificate2 x509Key = new X509Certificate2(certificateFilePath, password, flag);

                if (string.IsNullOrEmpty(password))
                {
                    asa = x509Key.PublicKey.Key;
                }
                else
                {
                    asa = x509Key.PrivateKey; 
                }                
            }
            else
            {
                if (easa == EnumASymmetricAlgorithm.RsaCsp)
                {
                    // RSACryptoServiceProviderサービスプロバイダ
                    asa = RSACryptoServiceProvider.Create(); // devps(1703)
                }

#if !NET45
                else if (easa == EnumASymmetricAlgorithm.RsaCng)
                {
                    // RSACngサービスプロバイダ
                    asa = RSACng.Create(); // devps(1703)
                }
#endif
#if NETSTD
                else if (easa == EnumASymmetricAlgorithm.RsaOpenSsl)
                {
                    // RSAOpenSslサービスプロバイダ
                    asa = RSAOpenSsl.Create(); // devps(1703)
                }
#endif
            }
            return asa;
        }

        #endregion

        #region CreateDigitalSignSP
        /// <summary>署名・検証サービスプロバイダの生成</summary>
        /// <param name="eaa">EnumDigitalSignAlgorithm</param>
        /// <param name="aa">
        /// AsymmetricAlgorithm
        /// - RSACryptoServiceProvider
        /// - DSACryptoServiceProvider
        /// </param>
        /// <param name="ha">
        /// HashAlgorithm
        /// </param>
        public static void CreateDigitalSignSP(
            EnumDigitalSignAlgorithm eaa, out AsymmetricAlgorithm aa, out HashAlgorithm ha)
        {
            aa = null;
            ha = null;

            // 公開鍵・暗号化サービスプロバイダ
            if (eaa == EnumDigitalSignAlgorithm.RsaCSP_MD5
                || eaa == EnumDigitalSignAlgorithm.RsaCSP_SHA1
                || eaa == EnumDigitalSignAlgorithm.RsaCSP_SHA256
                || eaa == EnumDigitalSignAlgorithm.RsaCSP_SHA384
                || eaa == EnumDigitalSignAlgorithm.RsaCSP_SHA512)
            {
                // RSACryptoServiceProviderサービスプロバイダ
                aa = new RSACryptoServiceProvider();

                switch (eaa)
                {
                    case EnumDigitalSignAlgorithm.RsaCSP_MD5:
                        ha = MD5.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaCSP_SHA1:
                        ha = SHA1.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaCSP_SHA256:
                        ha = SHA256.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaCSP_SHA384:
                        ha = SHA384.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaCSP_SHA512:
                        ha = SHA512.Create();
                        break;
                }
            }
#if NETSTD
            else if (eaa == EnumDigitalSignAlgorithm.RsaOpenSsl_MD5
                || eaa == EnumDigitalSignAlgorithm.RsaOpenSsl_SHA1
                || eaa == EnumDigitalSignAlgorithm.RsaOpenSsl_SHA256
                || eaa == EnumDigitalSignAlgorithm.RsaOpenSsl_SHA384
                || eaa == EnumDigitalSignAlgorithm.RsaOpenSsl_SHA512)
            {
                // RSAOpenSslサービスプロバイダ
                aa = new RSAOpenSsl();

                switch (eaa)
                {
                    case EnumDigitalSignAlgorithm.RsaOpenSsl_MD5:
                        ha = MD5.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaOpenSsl_SHA1:
                        ha = SHA1.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaOpenSsl_SHA256:
                        ha = SHA256.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaOpenSsl_SHA384:
                        ha = SHA384.Create();
                        break;
                    case EnumDigitalSignAlgorithm.RsaOpenSsl_SHA512:
                        ha = SHA512.Create();
                        break;
                }
            }
#endif
            else if (eaa == EnumDigitalSignAlgorithm.DsaCSP_SHA1)
            {
                // DSACryptoServiceProvider
                aa = new DSACryptoServiceProvider();
                ha = SHA1.Create();
            }
#if NETSTD
            else if (eaa == EnumDigitalSignAlgorithm.DsaOpenSsl_SHA1)
            {
                // DSAOpenSslサービスプロバイダ
                aa = new DSAOpenSsl();
                ha = SHA1.Create();
            }
#endif
            else if (
                eaa == EnumDigitalSignAlgorithm.ECDsaCng_P256
                || eaa == EnumDigitalSignAlgorithm.ECDsaCng_P384
                || eaa == EnumDigitalSignAlgorithm.ECDsaCng_P521)
            {
                // ECDsaCngはCngKeyが土台で、
                // ECDsaCng生成後にオプションとして設定するのではなく
                // CngKeyの生成時にCngAlgorithmの指定が必要であるもよう。
                CngAlgorithm cngAlgorithm = null;
                switch (eaa)
                {
                    case EnumDigitalSignAlgorithm.ECDsaCng_P256:
                        cngAlgorithm = CngAlgorithm.ECDsaP256;
                        break;
                    case EnumDigitalSignAlgorithm.ECDsaCng_P384:
                        cngAlgorithm = CngAlgorithm.ECDsaP384;
                        break;
                    case EnumDigitalSignAlgorithm.ECDsaCng_P521:
                        cngAlgorithm = CngAlgorithm.ECDsaP521;
                        break;
                }
                aa = new ECDsaCng(CngKey.Create(cngAlgorithm));
                ha = null; // ハッシュ無し
            }
#if NETSTD
            else if (
                eaa == EnumDigitalSignAlgorithm.ECDsaOpenSsl_P256
                || eaa == EnumDigitalSignAlgorithm.ECDsaOpenSsl_P384
                || eaa == EnumDigitalSignAlgorithm.ECDsaOpenSsl_P521)
            {
                ECCurve eCCurve = ECCurve.NamedCurves.nistP256;
                ECParameters eCParameters;
                ECDsa eCDsa = null;
                ECDsaOpenSsl eCDsaOpenSsl = null;

                switch (eaa)
                {
                    case EnumDigitalSignAlgorithm.ECDsaOpenSsl_P256:
                        eCCurve = ECCurve.NamedCurves.nistP256;
                        break;
                    case EnumDigitalSignAlgorithm.ECDsaOpenSsl_P384:
                        eCCurve = ECCurve.NamedCurves.nistP384;
                        break;
                    case EnumDigitalSignAlgorithm.ECDsaOpenSsl_P521:
                        eCCurve = ECCurve.NamedCurves.nistP521;
                        break;
                }

                // https://qiita.com/yoship1639/items/6dd0cc8623d7f3969d78
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    eCDsa = ECDsa.Create(); // ECDsaOpenSslと思われる。
                    eCDsa.GenerateKey(eCCurve);
                    eCParameters = eCDsa.ExportParameters(true);
                    eCDsaOpenSsl = new ECDsaOpenSsl(eCParameters.Curve);
                    eCDsaOpenSsl.ImportParameters(eCParameters);
                }

                aa = eCDsaOpenSsl;
                ha = null; // ハッシュ無し
            }
#endif
            else
            {
                throw new ArgumentException(
                    PublicExceptionMessage.ARGUMENT_INCORRECT,
                    "EnumDigitalSignAlgorithm parameter is incorrect.");
            }
        }
        #endregion
    }
}
