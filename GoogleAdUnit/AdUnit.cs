/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.ComponentModel;

namespace SFE.GoogleAdUnit
{
    [
        DefaultProperty("AffiliateId"),
        ToolboxData("<{0}:AdUnit runat=\"server\"></{0}:AdUnit>")
    ]
    public class AdUnit : BaseAdUnit
    {
        #region Class Members
        private AdUnitType m_AdUnitType = AdUnitType.TextAndImage;
        private AdUnitFormat m_AdUnitFormat = AdUnitFormat.LeaderBoard_728x90_H;
        #endregion

        #region Public Properties
 
        /// <summary>
        /// 
        /// </summary>
        public AdUnitType AdUnitType
        {
            get { return this.m_AdUnitType; }
            set { this.m_AdUnitType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AdUnitFormat AdUnitFormat
        {
            get { return this.m_AdUnitFormat; }
            set { this.m_AdUnitFormat = value; }
        }

        #endregion

        #region Helper Methods
        override protected void DesignTimeRender(System.Web.UI.HtmlTextWriter writer)
        {
            StringBuilder strStream = new StringBuilder();

            UnitDimensions obDim = AdUnitGlobals.g_AdUnitDimensions[this.AdUnitFormat] as UnitDimensions;
			strStream.AppendFormat(AdUnitGlobals.g_strAdUnitDesigntimeRender, obDim.WIDTH, obDim.HEIGHT, DrawingUtil.GetColorHexFormat(this.BorderColor, false), DrawingUtil.GetColorHexFormat(this.TextColor, false), DrawingUtil.GetColorHexFormat(this.BackColor, false), "&nbsp;");

            writer.Write(strStream.ToString());
        }
 
        protected override void InsertSpecificScript(HtmlTextWriter writer)
        {
            writer.Write(String.Format("google_ad_type=\"{0}\";", this.GetAdType()));
        }

		override protected String GetAdFormat()
		{
			switch (this.AdUnitFormat)
			{
		        case AdUnitFormat.Banner_468x60_H:
					return "468x60_as";
				case AdUnitFormat.HalfBanner_234x60_H:
					return "234x60_as";
				case AdUnitFormat.SkyScapper_120x600_V:
					return "120x600_as";
				case AdUnitFormat.WideSkyScrapper_160x600_V:
					return "160x600_as";
				case AdUnitFormat.VerticalBanner_120x240_V:
					return "120x240_as";
				case AdUnitFormat.Button_125x125_S:
					return "125x125_as";
				case AdUnitFormat.MediumRectangle_300x250_S:
					return "300x250_as";
				case AdUnitFormat.Square_250x250_S:
					return "250x250_as";
				case AdUnitFormat.LargeRectangle_336x280_S:
					return "336x280_as";
				case AdUnitFormat.SmallRectangle_180x150_S:
					return "180x150_as";
				case AdUnitFormat.LeaderBoard_728x90_H:
				default:
					return "728x90_as";
			}
		}

		override protected String GetAdType()
		{
			switch (this.AdUnitType)
			{
				case AdUnitType.TextOnly:
					return "text";
				case AdUnitType.ImageOnly:
					return "image";
				case AdUnitType.TextAndImage:
				default:
					return "text_image";
			}
		}

        internal override UnitDimensions GetUnitDimensions()
        {
            return AdUnitGlobals.g_AdUnitDimensions[this.AdUnitFormat] as UnitDimensions;
        }
        #endregion
    }
}
