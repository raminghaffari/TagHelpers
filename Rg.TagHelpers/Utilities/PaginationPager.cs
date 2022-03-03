namespace Rg.TagHelpers.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="PaginationPager" />.
    /// </summary>
    public class PaginationPager
    {


        /// <summary>
        /// Gets the Pages.
        /// </summary>
        public IEnumerable<int> Pages { get; private set; }

        /// <summary>
        /// Gets the TotalPages.
        /// </summary>
        public int TotalPages { get; private set; }




        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationPager"/> class.
        /// </summary>
        /// <param name="totalItems">The totalItems<see cref="long"/>.</param>
        /// <param name="currentPage">The currentPage<see cref="int"/>.</param>
        /// <param name="pageSize">The pageSize<see cref="int"/>.</param>
        /// <param name="maxPages">The maxPages<see cref="int"/>.</param>
        public PaginationPager
            (
              long totalItems = 100,
              int currentPage = 1,
              int pageSize = 20,
              int maxPages = 5
            )

        {
            // calculate total pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            // ensure current page isn't out of range
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }

            int startPage, endPage;

            if (totalPages <= maxPages)
            {
                // total pages less than max so show all pages
                startPage = 1;
                endPage = totalPages;
            }
            else
            {
                // total pages more than max so calculate start and end pages
                var maxPagesBeforeCurrentPage = (int)Math.Floor((decimal)maxPages / (decimal)2);
                var maxPagesAfterCurrentPage = (int)Math.Ceiling((decimal)maxPages / (decimal)2) - 1;
                if (currentPage <= maxPagesBeforeCurrentPage)
                {
                    // current page near the start
                    startPage = 1;
                    endPage = maxPages;
                }
                else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
                {
                    // current page near the end
                    startPage = totalPages - maxPages + 1;
                    endPage = totalPages;
                }
                else
                {
                    // current page somewhere in the middle
                    startPage = currentPage - maxPagesBeforeCurrentPage;
                    endPage = currentPage + maxPagesAfterCurrentPage;
                }
            }
            // calculate start and end item indexes
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.Min(startIndex + pageSize - 1, totalItems - 1);

            // create an array of pages that can be looped over
            var pages = Enumerable.Range(startPage, (endPage + 1) - startPage);


            TotalPages = totalPages;
            Pages = pages;
        }

    }
}
