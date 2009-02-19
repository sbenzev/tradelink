/*
 * Created by SharpDevelop.
 * User: josh
 * Date: 2/7/2008
 * Time: 10:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using TradeLink.Common;
using TradeLink.API;

namespace Responses
{
	/// <summary>
	/// Simple-Moving-Average class used by other responsees
	/// </summary>
	public class SMA
	{
		public SMA()
		{
		}
		
		public static decimal BarSMA(BarList bl, BarInterval bi, int barsback)
		{
			if (!bl.Has(barsback)) return bl.RecentBar.Close;
			decimal sum = 0;
            for (int i = 0; i < barsback; i++)
            {
                try
                {
                    sum += bl[bl.Last - i, bi].Close;
                } 
                catch (ArgumentOutOfRangeException) 
                { 
                    // ArgumentOutOfRange is thrown when:
                    // (bars requested) > (bars you have)
                    // TO FIX:
                    // make sure you call bl.Has(NumOfBarsYouNeed)
                    // before you call bl.Get(BarNumIDontYetHave)
                }
            }
			return sum/barsback;
		}
        public static decimal BarSMA(BarList bl, int barsback)
        {
            return BarSMA(bl, bl.Int, barsback);
        }

	}
}