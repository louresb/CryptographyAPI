# CryptographyAPI

[![licence mit](https://img.shields.io/badge/licence-MIT-blue.svg)](https://github.com/louresb/CryptographyAPI/blob/main/LICENSE)
![Development Status Badge](https://img.shields.io/badge/Status-In%20Progress-yellow)

This API is developed as a solution for a [challenge](https://github.com/backend-br/desafios) offered by [Back-End Brasil](https://github.com/backend-br),  the official community hub for Brazilian backenders.

## Technologies Used

- C#
- .NET
- ASP.NET
- Entity Framework Core
- Micrsoft SQLServer

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

## License
[MIT License](https://github.com/louresb/CryptographyAPI/blob/main/LICENSE) © [Bruno Loures](https://github.com/louresb)
