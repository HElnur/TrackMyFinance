using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyFinance.Domain.Enums
{
    public enum ErrorCodes
    {
        [Description("Email or password is incorrect.")]
        EMAIL_OR_PASSWORD_IS_NOT_CORRECT = 1_0_0,

        [Description("Password is incorrect")]
        PASSWORD_IS_INCORRECT = 1_1_0,

        [Description("Information not found.")]
        INFORMATION_NOT_FOUND = 2_1_1,

        [Description("This data is already exist.")]
        DATA_IS_ALREADY_EXIST = 2_1_2,

        [Description("There are some validations error.")]
        VALIDATION_ERROR = 3_0_0,
    }
}
