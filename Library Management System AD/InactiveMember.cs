using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  InactiveMember
    ///
    /// @brief  An inactive member.
    ///         -- member that hasn't borrowed in last 31 days.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class InactiveMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LastBorrowedBook { get; set; }
        public string LastBorrowedDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}