using System;
using System.Collections.Generic;
using System.Text;
using CICC.WR.AnnualPartyDAL;

namespace CICC.WR.AnnualPartyControls
{
   public class DrawLottery
    {
       public DrawLottery(int award )
       {
           Winners = new List<MyEmployee>();
           this.Award = award;
       }

       /// <summary>
       /// 奖项
       /// </summary>
       public int Award { get; set; }

       /// <summary>
       /// 奖项显示字符串
       /// </summary>
       public string AwardString { get; set; }
       ///// <summary>
       ///// 最多产生多少个中奖者
       ///// </summary>
       //public int MaxCount { get; set; }
       /// <summary>
       /// 一页抽奖多少中奖者
       /// </summary>
       public int OnePageCount { get; set; }

       private int onePageColumn = 5;

       /// <summary>
       /// 一页有多少列
       /// </summary>
       public int OnePageColumn
       {
           get { return onePageColumn; }
           set { onePageColumn = value; }
       }
       
       /// <summary>
       /// 要抽几次
       /// </summary>
       public int PageCount { get; set; }

       /// <summary>
       /// 中奖者名单
       /// </summary>
       public List<MyEmployee> Winners { get; set; }

       /// <summary>
       /// 抽完该奖后接下来抽的奖
       /// </summary>
       public DrawLottery NextDrawLottery { get; set; }
    }
}
