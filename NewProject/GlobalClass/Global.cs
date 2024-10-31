using krate_business_layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject.GlobalClass
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username,string Password)
        {
            string CurrentDirectory=System.IO.Directory.GetCurrentDirectory();

            string FilePath=CurrentDirectory+ "\\data.txt";
            try
            {
                if (string.IsNullOrEmpty(Username) && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }
                string Data = Username + "#//#" + Password;

                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    sw.WriteLine(Data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                  MessageBox.Show($"An Error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username,ref string Password)
        {
            try
            {
                string CurrentDirictory = System.IO.Directory.GetCurrentDirectory();

                string FillPath = CurrentDirictory + "\\data.txt";
                if(File.Exists(FillPath))
                {
                    using(StreamReader reader=new StreamReader(FillPath))
                    {
                        string line;
                        while((line=reader.ReadLine()) != null)
                        {
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            Username = result[0];
                            Password = result[1];
                        }
                        return true;

                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool ChecAccessDenied(clsUser.enPermissions enPermissions)
        {
            if(CurrentUser.Permissions == (int)clsUser.enPermissions.All)
            {
                return true;
            }

            return ((int)enPermissions & CurrentUser.Permissions) == (int)enPermissions;

        }

        public static bool DelteCurrentUserUserAndDontremember()
        {
            CurrentUser = null;
            // Add code to forget stored credentials (optional)
            RememberUsernameAndPassword("", "");
            return true;
        }




    }
}
