﻿/////////////////////////////////////////////////////////////////////////////////
// Paint.NET                                                                   //
// Copyright (C) dotPDN LLC, Rick Brewster, Tom Jackson, and contributors.     //
// Portions Copyright (C) Microsoft Corporation. All Rights Reserved.          //
// See license-pdn.txt for full licensing and attribution details.             //
//                                                                             //
// Ported to Pinta by: Jonathan Pobst <monkey@jpobst.com>                      //
/////////////////////////////////////////////////////////////////////////////////

using System;

namespace Pinta.Core
{
	public class CheckerBoardOperation
	{
		public ColorBgra Apply (ColorBgra color, int checkerX, int checkerY)
		{
			int b = color.B;
			int g = color.G;
			int r = color.R;
			int a = color.A;

			int v = ((checkerX ^ checkerY) & 8) * 8 + 191;
			a = a + (a >> 7);
			int vmia = v * (256 - a);

			r = ((r * a) + vmia) >> 8;
			g = ((g * a) + vmia) >> 8;
			b = ((b * a) + vmia) >> 8;

			return ColorBgra.FromUInt32 ((uint)b + ((uint)g << 8) + ((uint)r << 16) + 0xff000000);
		}
	}
}
