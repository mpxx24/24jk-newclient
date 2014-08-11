using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _24jkClient.Client24jk;
using System.IO;

namespace _24jkClient
{
    public partial class WebForm1 : Page
    {
        private const string ServerPath = "C:\\24jk\\";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var client = new Service24Client("BasicHttpBinding_IService24");
            
            if (FileUpload1.HasFile)
                try
                {
                    FileUpload1.SaveAs(ServerPath + FileUpload1.FileName);
                    client.UploadPicToDb(ServerPath + FileUpload1.FileName, FileUpload1.PostedFile.FileName, 
                        FileUpload1.PostedFile.ContentType, FileUpload1.PostedFile.ContentLength);
                    
                    Label1.Text = "File name: " +
                            FileUpload1.PostedFile.FileName + "\n" +
                            FileUpload1.PostedFile.ContentLength + " \n" +
                            "Content type: " +
                            FileUpload1.PostedFile.ContentType;
                }
                catch (Exception ex)
                {
                    Label1.Text = "ERROR: " + ex.Message.ToString();
                }
            else
            {
                Label1.Text = "You have not specified a file.";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bufor = Directory.GetFiles(ServerPath).ToList();

            foreach (var s in bufor)
            {
                ListBox1.Items.Add(s.Substring(s.LastIndexOf('\\') + 1));
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var selectedFile = ListBox1.SelectedItem.Value;
            var file = new FileInfo(ServerPath + selectedFile);

            if (file.Exists)
            {
                Response.ClearContent();

                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else
            {
                Label1.Text = "sth isn't workin' son! :(";
            }

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFile = ListBox1.SelectedItem.Value;
            Image1.ImageAlign = ImageAlign.Right;
            Image1.ImageUrl = ServerPath + selectedFile;
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var selectedFile = ListBox1.SelectedItem.Value;
            Image1.ImageAlign = ImageAlign.Right;
            Image1.ImageUrl = ServerPath + selectedFile;
        }
       
    }
}