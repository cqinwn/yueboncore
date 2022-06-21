using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons
{
    /// <summary>
    /// ��������ַ���
    /// </summary>
    public static class UIConstants
    {
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public static string ApplicationExpiredDate = "12/29/2012";
        /// <summary>
        /// ����汾
        /// </summary>
        public static string SoftwareVersion = "3.0";
        /// <summary>
        /// �����Ʒ����
        /// </summary>
        public static string SoftwareProductName = "YuebonSoftSystem";
       
        /// <summary>
        /// �����������
        /// </summary>
        public static int SoftwareProbationDay = 20;

        /// <summary>
        /// �����洢Ŀ¼����
        /// </summary>
        public static string IsolatedStorageDirectoryName = "UserNameDir";
        /// <summary>
        /// �����洢����Կ
        /// </summary>
        public static string IsolatedStorageEncryptKey = "12345678";

        /// <summary>
        /// ע����ܹ�Կ
        /// </summary>
        public static string PublicKey = @"<RSAKeyValue><Modulus>mtDtu679/0quhftVyOc6/cBov/i534Dkh3AB8RwrpC9Vq2RIFB3uvjRUuaAEPR8vMcijQjVzqLZgMM7jFKclzbh21rWTM+YlOeraKz5FPCC7rSLnv6Tfbzia9VI/r5cfM8ogVMuUKCZeU+PTEmVviasCl8nPYyqOQchlf/MftMM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        /// <summary>
        /// ��Ȩ��Ϣ
        /// </summary>
        public static string CopyRight= string.Format("<strong>Copyright &copy; 2017-{0} <a href=\"http://www.yuebon.com\" target=\"_blank\">Yuebon Tech</a>.</strong>", DateTime.Now.Year);
        /// <summary>
        /// Web��֤��ַ
        /// </summary>
        public static string WebRegisterURL = "http://www.yuebon.com/WebRegister.aspx";

        /// <summary>
        /// ���ò���ֵ
        /// </summary>
        /// <param name="expiredDate">����ʱ��</param>
        /// <param name="version">����汾</param>
        /// <param name="name">�������</param>
        /// <param name="publicKey">��Կ�ַ���</param>
        public static void SetValue(string expiredDate, string version, string name, string publicKey)
        {
            UIConstants.ApplicationExpiredDate = expiredDate;
            UIConstants.SoftwareVersion = version;
            UIConstants.SoftwareProductName = name;
            UIConstants.PublicKey = publicKey;
        }
    }
}
