using AutoMapper;
using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.DTO;
using TestTask_10._02._2023.Models.VM;

namespace TestTask_10._02._2023.Helpers
{
    public class DtoAndEntityConversionProfile : Profile
    {
        private readonly IMapper _mapper = null;

        public DtoAndEntityConversionProfile()
        {
            // Create mapping for all entities, DTOs and VMs

            CreateMap<Position, PositionDto>();
            CreateMap<PositionDto, Position>();
            CreateMap<PositionDto, PositionVM>();
            CreateMap<PositionVM, PositionDto>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeDto, EmployeeVM>();
            CreateMap<EmployeeVM, EmployeeDto>();
        }
    }

    public static class ConversionExtension
    {
        private static IMapper _mapper = null;

        public static void InitMapper(IMapper mapper)
        {
            if (_mapper is null)
                _mapper = mapper;
        }

        public static Position ToEntity(this PositionDto positionDto)
        {
            if (positionDto is null)
                return null;
            else
                return _mapper.Map<Position>(positionDto);
        }

        public static PositionDto ToDto(this Position positionEntity)
        {
            if (positionEntity is null)
                return null;
            else
                return _mapper.Map<PositionDto>(positionEntity);
        }

        public static PositionDto ToDto(this PositionVM positionVM)
        {
            if (positionVM is null)
                return null;
            else
                return _mapper.Map<PositionDto>(positionVM);
        }

        public static PositionVM ToVM(this PositionDto positionDto)
        {
            if (positionDto is null)
                return null;
            else
                return _mapper.Map<PositionVM>(positionDto);
        }

        public static Employee ToEntity(this EmployeeDto employeeDto)
        {
            if (employeeDto is null)
                return null;
            else
                return _mapper.Map<Employee>(employeeDto);
        }

        public static EmployeeDto ToDto(this Employee employeeEntity)
        {
            if (employeeEntity is null)
                return null;
            else
                return _mapper.Map<EmployeeDto>(employeeEntity);
        }

        public static EmployeeDto ToDto(this EmployeeVM employeeVM)
        {
            if (employeeVM is null)
                return null;
            else
            {
                var employeeDto = _mapper.Map<EmployeeDto>(employeeVM);
                return employeeDto;
            }
        }

        public static EmployeeVM ToVM(this EmployeeDto employeeDto)
        {
            if (employeeDto is null)
                return null;
            else
            {
                var employeeVM = _mapper.Map<EmployeeVM>(employeeDto);
                foreach(var pos in employeeDto.Positions)
                {
                    employeeVM.PositionsIds.Add(pos.Id);
                }

                return employeeVM;
            }
        }

        public static List<Position> ToEntity(this List<PositionDto> positionDtoList)
        {
            if (positionDtoList is null)
                return new List<Position>();
            else
            {
                var positionList = new List<Position>();
                foreach (var position in positionDtoList)
                {
                    positionList.Add(new Position()
                    {
                        Id = position.Id,
                        Name = position.Name,
                        Employees = position.Employees,  
                        Grade = position.Grade,
                    });
                }
                return positionList;
            }
        }
    }
}
