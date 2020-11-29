﻿namespace GoodWeebs.Web.Areas.Administration.Controllers
{
    using GoodWeebs.Common;
    using GoodWeebs.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
