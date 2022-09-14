using AutoMapper;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.Dtos
{
    public class CodeGeneratorProfile : Profile
    {
        public CodeGeneratorProfile()
        {
           CreateMap<CodeColumns, CodeColumnsOutputDto>();
           CreateMap<CodeColumnsInputDto, CodeColumns>();
           CreateMap<CodeTable, CodeTableOutputDto>();
           CreateMap<CodeTableInputDto, CodeTable>();
           CreateMap<Database, DatabaseOutputDto>();
           CreateMap<DatabaseInputDto, Database>();

        }
    }
}
