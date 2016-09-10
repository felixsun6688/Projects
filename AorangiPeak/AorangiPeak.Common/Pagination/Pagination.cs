using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorangiPeak.Common.Pagination
{
    public class Pagination
    {
        public static readonly int PagSize = 5;
        public static readonly int AdminPagSize = 10;

        public static string GetPageInfo(int currentPage, int totalCount, string controller)
        {
            int totalPage = totalCount / PagSize;

            if (totalCount % 2 > PagSize)
                totalPage++;

            string prevPage = string.Empty;
            string nextPage = string.Empty;
            string pageInfo = string.Empty;

            prevPage = currentPage - 1 > 0 ? "<div class='border1'>< div class='pre'><a href='/" + controller + "/Index/?page=" + (currentPage - 1) + "'> Prev </ a>"
                                    + "</ div>< div class='number'><ul>"
                                    : "<div class='border1'>< div class='pre'><a> Prev </ a></ div>< div class='number'><ul>";

            nextPage = currentPage + 1 > totalPage ? "</ul></ div ><div class='next'><a> Next </ a></ div>< div class='clearfix'></div></div>"
                              : "</ul></ div ><div class='next'><a href='/" + controller + "/Index/?page=" + (currentPage + 1) + "'> Next </ a>"
                              + "</ div>< div class='clearfix'></div></div>";

            pageInfo += prevPage;

            for (int i = 1; i < totalPage + 1; i++)
            {
                if (i == currentPage)
                {
                    pageInfo += "<li><a>" + i + "</a></li>";
                }
                else
                {
                    pageInfo += "<li><a href='/" + controller + "/Index/?page=" + i + "'>" + i + "</a></li>";
                }
            }

            return pageInfo + nextPage;
        }

        public static string GetAdminPageInfo(int currentPage, int totalCount, string controller, string action, string option)
        {
            int totalPage = totalCount / AdminPagSize;

            if (totalCount % AdminPagSize > 0)
                totalPage++;

            string pageInfo = string.Empty;
            string nextPage = string.Empty;
            string prevPage = string.Empty;

            prevPage = currentPage - 1 > 0 ? "<li class='prev'>"
                                    + "<a href='/APManage/" + controller + "/"+action+"/?page=" + (currentPage - 1) + "&"+option+"' class='btn btn-default'>← Prev</a>"
                                    + "</li>"
                                    : "<li class='prev'>"
                                    + "<a class='btn btn-default disabled'>← Prev</a>"
                                    + "</li>";

            nextPage = currentPage + 1 > totalPage ? "<li class='next'>"
                                + "<a class='btn btn-default disabled'>Next →</a>"
                                + "</li>"
                                : "<li class='next'>"
                                + "<a href='/APManage/" + controller + "/"+action+"/?page=" + (currentPage + 1) + "&" + option + "' class='btn btn-default'>Next →</a>"
                                + "</li>";

            pageInfo += prevPage;

            for (int i = 1; i < totalPage + 1; i++)
            {
                if (i == currentPage)
                {
                    pageInfo += "<li class='active'><a class='btn btn-default disabled'>" + i + "</a></li>";
                }
                else
                {
                    pageInfo += "<li><a class='btn btn-default' href='/APManage/" + controller +"/" + action + "/?page=" + i + "&" + option + "'>" + i + "</a></li>";
                }
            }

            return pageInfo + nextPage; ;
        }
    }
}
