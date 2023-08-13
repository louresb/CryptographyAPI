# CryptographyAPI

[![licence mit](https://img.shields.io/badge/licence-MIT-blue.svg)](https://github.com/louresb/CryptographyAPI/blob/main/LICENSE)
![Development Status Badge](https://img.shields.io/badge/Status-Completed-green)

This API is developed as a solution for a [challenge](https://github.com/backend-br/desafios) offered by [Back-End Brasil](https://github.com/backend-br), the official community hub for Brazilian backenders.

## Technologies Used

- C#
- .NET
- ASP.NET
- Entity Framework Core
- Microsoft SQL Server

# Challenge description

Your challenge will be to implement encryption in a service transparently for both the API and the service layers of your application. The goal is to ensure that sensitive fields of entity objects are not directly visible. This will involve performing encryption at runtime during the conversion of entities to the corresponding columns in the database, and vice versa.

## Example

Consider the fields "userDocument" and "creditCardToken" as sensitive fields that need to be encrypted. The example table would look like this:

| id | userDocument     | creditCardToken | value |
|:---|:-----------------|:----------------|:------|
| 1  | MzYxNDA3ODE4MzM= | YWJjMTIz        | 5999  |
| 2  | MzI5NDU0MTA1ODM= | eHl6NDU2        | 1000  |
| 3  | NzYwNzc0NTIzODY= | Nzg5eHB0bw==    | 1500  |

The structure of the corresponding entity would be as follows:

| Field           | Type   |
|:----------------|:-------|
| id              | Long   |
| userDocument    | String |
| creditCardToken | String |
| value           | Long   |

## Requirements

- Implement a simple CRUD considering the aforementioned fields as sensitive.
- Use the encryption algorithm of your preference.

## Screenshots

<div align="center">

### Post new user
![Post](https://github.com/louresb/CryptographyAPI/assets/103293696/3706150b-543a-4f6b-a391-8568c35e2672) ![Post 200](https://github.com/louresb/CryptographyAPI/assets/103293696/cc769d26-0c25-4492-a34b-56bbe15ec291)

### "userDocument" and "creditCardToken" encrypted at the database
![Db encrypted](https://github.com/louresb/CryptographyAPI/assets/103293696/15ad45a8-d973-4d09-bffb-ee509837dc69) 

### Get decrypted data from database
![Get](https://github.com/louresb/CryptographyAPI/assets/103293696/803e27b3-a0b2-4f13-94aa-5d3e493ee74a)

</div>

## Installation

1. Clone the repository: 

```powershell

git clone https://github.com/louresb/CryptographyAPI

```

2. Navigate to the project directory:

```powershell

cd CryptographyAPI

```

3. Build the project:

```powershell

dotnet build

```

4. Make sure to have SQL Server 

```powershell

dotnet ef database update

```

5. Run the project:

```powershell

dotnet run

```

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License
[MIT License](https://github.com/louresb/CryptographyAPI/blob/main/LICENSE) © [Bruno Loures](https://github.com/louresb)
