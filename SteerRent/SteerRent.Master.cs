using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SteerRent
{
    public partial class SteerRent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //AddEventHandlers();
                //AddPageContent();
            }
        }

        private void AddPageContent()
        {
            string pageName = HttpContext.Current.Request.Url.AbsolutePath.Substring(
                         HttpContext.Current.Request.Url.AbsolutePath.LastIndexOf("/") + 1);

            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)this.Page.Master.FindControl("HeadContent");
            Label label = new Label();
            label.Text = " <br /> Content for page: " + pageName;
            contentPlaceHolder.Controls.Add(label);
        }

        private void AddEventHandlers()
        {
            //NavigationMenu.MenuItemDataBound += new MenuEventHandler(NavigationMenu_MenuItemDataBound);
            //SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(SiteMap_SiteMapResolve);
            //SiteMapPath1.ItemCreated += new SiteMapNodeItemEventHandler(SiteMapPath1_ItemCreated);
        }

        void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            SiteMapNode node = (SiteMapNode)e.Item.DataItem;

            //set the target of the navigation menu item (blank, self, etc...)
            if (node["target"] != null)
            {
                e.Item.Target = node["target"];
            }

            //create access key button
            if (node["accesskey"] != null)
            {
                CreateAccessKeyButton(node["accesskey"] as string, node.Url);
            }
        }

        //create access key button
        void CreateAccessKeyButton(string ak, string url)
        {
            HtmlButton inputBtn = new HtmlButton();
            inputBtn.Style.Add("width", "1px");
            inputBtn.Style.Add("height", "1px");
            inputBtn.Style.Add("position", "absolute");
            inputBtn.Style.Add("left", "-2555px");
            inputBtn.Style.Add("z-index", "-1");
            inputBtn.Attributes.Add("type", "button");
            inputBtn.Attributes.Add("value", "");
            inputBtn.Attributes.Add("accesskey", ak);
            inputBtn.Attributes.Add("onclick", "navigateTo('" + url + "');");

            AccessKeyPanel.Controls.Add(inputBtn);
        }

        protected void SiteMapPath1_ItemCreated(object sender, SiteMapNodeItemEventArgs e)
        {
            if (e.Item.ItemType == SiteMapNodeItemType.Root)
            {
                SiteMapPath1.PathSeparator = " ";
            }
            else
            {
                SiteMapPath1.PathSeparator = " >> ";
            }
        }

        //http://msdn.microsoft.com/en-us/library/system.web.sitemap.sitemapresolve.aspx
        //solve > SiteMapNode is readonly, property Title cannot be modified. 

        SiteMapNode SiteMap_SiteMapResolve(object sender, SiteMapResolveEventArgs e)
        {
            if (SiteMap.CurrentNode != null)
            {
                SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
                SiteMapNode tempNode = currentNode;
                tempNode = ReplaceNodeText(tempNode);

                return currentNode;
            }

            return null;
        }

        //remove <u></u> tag recursively
        internal SiteMapNode ReplaceNodeText(SiteMapNode smn)
        {
            //current node
            if (smn != null && smn.Title.Contains("<u>"))
            {
                smn.Title = smn.Title.Replace("<u>", "").Replace("</u>", "");
            }

            //parent nd
            if (smn.ParentNode != null)
            {
                if (smn.ParentNode.Title.Contains("<u>"))
                {
                    SiteMapNode gpn = smn.ParentNode;
                    smn.ParentNode.Title = smn.ParentNode.Title.Replace("<u>", "").Replace("</u>", "");
                    smn = ReplaceNodeText(gpn);
                }
            }
            return smn;
        }
    }
}