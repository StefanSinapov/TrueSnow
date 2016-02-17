﻿using System.Collections.Generic;

namespace TrueSnow.Web.ViewModels.Comments
{
    public class CommentsByPostViewModel
    {
        public List<CommentViewModel> Comments { get; set; }

        public int TotalPages { get; set; }

        public string PostUrl { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage { get; set; }

        public int NextPage { get; set; }
    }
}