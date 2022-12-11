namespace Company.API.Models.DataTransferObjects;

public record NewEmployeeDto
{
    public static NewEmployeeDto Create()
    {
        return new NewEmployeeDto();
    }
}