﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountIt.Interfaces
{
	public interface IContentLoader
	{
		Task<string> LoadContent(string path, string filename);
	}
}
