# employee-benefits-package

## Build

`dotnet build`

## Tests

`dotnet test`

## Run

`dotnet run --project EmployeeBenefitsPackage`

### Testing APIs with Swagger
1. Open your preferred browser.
2. Navigate to [https://localhost:7009/swagger](https://localhost:7009/swagger).

### Testing APIs with Postman/Insomnia
POST https://localhost:7009/Employee

Request body:
```
{
	"name": "Vinicius"
}
```

Response body:
```
{
	"dependents": [],
	"id": 1,
	"name": "Vinicius"
}
```

POST https://localhost:7009/Dependent

Request body:
```
{
	"name": "Jacques",
	"employeeId": 1
}
```

Response body:
```
{
	"employeeId": 1,
	"id": 1,
	"name": "Jacques"
}
```

GET https://localhost:7009/BenefitsPackage?employeeId=1

Response body:
```
{
	"employee": {
		"dependents": [
			{
				"employeeId": 1,
				"id": 1,
				"name": "Jacques"
			}
		]
		"id": 1,
		"name": "Vinicius",
	},
	"totalBenefitsCost": 1500,
	"salary": 52000,
	"discountedSalary": 50500,
	"basePaycheck": 2000,
	"discountedPaycheck": 1942.3076923076924
}
```