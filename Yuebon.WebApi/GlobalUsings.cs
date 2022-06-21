﻿global using Autofac;
global using Autofac.Extensions.DependencyInjection;
global using AutoMapper;
global using log4net;
global using log4net.Repository;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.HttpOverrides;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq;
global using System.Reflection;
global using System.Text.Encodings.Web;
global using System.Text.Json;
global using System.Text.Unicode;
global using System.Threading.Tasks;
global using UAParser;
global using Yitter.IdGenerator;
global using Yuebon.AspNetCore.Common;
global using Yuebon.AspNetCore.Controllers;
global using Yuebon.AspNetCore.Models;
global using Yuebon.AspNetCore.Mvc;
global using Yuebon.AspNetCore.Mvc.Filter;
global using Yuebon.Commons.Cache;
global using Yuebon.Commons.Converter;
global using Yuebon.Commons.Core.App;
global using Yuebon.Commons.Core.Dtos;
global using Yuebon.Commons.Core.UnitOfWork;
global using Yuebon.Commons.Dtos;
global using Yuebon.Commons.Extend;
global using Yuebon.Commons.Extensions;
global using Yuebon.Commons.Filters;
global using Yuebon.Commons.Helpers;
global using Yuebon.Commons.Json;
global using Yuebon.Commons.Log;
global using Yuebon.Commons.Mapping;
global using Yuebon.Commons.Models;
global using Yuebon.Commons.Module;
global using Yuebon.Commons.Net;
global using Yuebon.Commons.Options;
global using Yuebon.Commons.SeedInitData;
global using Yuebon.Extensions.ServiceExtensions;
global using Yuebon.Security.Dtos;
global using Yuebon.Security.IServices;
global using Yuebon.Security.Models;
global using Yuebon.WebApi.Areas.Security.Models;
global using MediatR;