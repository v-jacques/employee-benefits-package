# employee-benefits-package

## Build

`dotnet build`

## Tests

`dotnet test`

## Run

`dotnet run --project EmployeeBenefitsPackage`

### Testing APIs with Swagger
1. Open your preferred browser.
2. Navigate to [http://localhost:5000/swagger](http://localhost:5000/swagger).

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
	"id": 1,
	"name": "Vinicius",
	"dependents": null
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
	"id": 1,
	"employeeId": 1,
	"name": "Jacques"
}
```

GET https://localhost:7009/BenefitsPackage?employeeId=1

Response body:
```
{
	"employee": {
		"id": 1,
		"name": "Vinicius",
		"dependents": [
			{
				"id": 1,
				"employeeId": 1,
				"name": "Jacques"
			}
		]
	},
	"totalBenefitsCost": 1500,
	"salary": 52000,
	"discountedSalary": 50500,
	"monthlySalary": 2000,
	"monthlyDiscountedSalary": 1942.3076923076924
}
```