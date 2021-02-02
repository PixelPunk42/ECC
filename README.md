# ECC
Eppendorf Coding Challenge

Task: create a Frontend that is capable of CRUD operations on a database seeded by a JSON file.

Used technologies:
* WPF / .NET Core 3.1
* Entity Framework Core Sqlite 5.0.2
* System.Text.Json 5.0.1

Usage should be self-explanatory

Known issues:
* no time left for unit tests :(
* DataGrid view refuses to update after delete operations, pressing delete on an already deleted row will lead to a crash. (see comments in DeviceRepository.DeleteDevice)

TO DO:
* unit tests
* input validation for new devices
* error handling
* user feedback after operations
* user confirmation dialog for delete operation
* GUI could use a face lift...