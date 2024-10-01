# ADO.NET
## 1. Introduction
**1. Stands for Microsoft ActiveX data Object.**

**2. ADO.NET is one of Microsoft’s data access technologies,**

**3. Data access (Ex:ADO.NET ,Entity Framework Core  )refers to the ability to
retrieve and use data stored in a database or 
other storage system, while a data source(EX:Sql server) is the collection of
technical information needed to access that data**

**4. It is a part of the .NET Framework, which establishes a connection between the .NET Application and different data sources. The Data Sources 
can be SQL Server, Oracle, MySQL, XML, etc.**
## 2. Componenets of ADO.NET
### Connection
**The Connection component establishes a connection to
a data source, such as a database(Open , close)**
### Command
**The Command component represents a command that is
executed against a data source.**
### DataReader
** The DataReader component efficiently reads data from
a data source. It provides a forward-only, read-only
stream of data that is
particularly useful for retrieving large datasets.**
### DataAdapter
****
### DataSet
### DataTable

## 3. SQLCommand builder 

**1. It automatically generates the necessary INSERT, 
UPDATE, and DELETE Transact-SQL (T-SQL) statements
based on the information retrieved by the SelectCommand 
property of a SqlDataAdapter.**

**2. If there are primary or unique keys in the
table schema, the SqlCommandBuilder uses them to 
formulate the UPDATE statements.
Otherwise, it throws an InvalidOperationException 
because it needs a way to identify which rows in the
database should be updated.**

## 3. Validation Controls

### => The RequiredFieldValidator Control 

**Ensures that the user does 
not skip a mandatory entry field .**

### => The CompareValidator Control 

**Compares one controls value with another
controls value, constants and data type using a
comparison operator
(equals, greater than, less than, and so on).**
### => The RangeValidator Control 

**Checks the user's input is in a given range
(eg: numbers or characters).**
### => The RegularExpressionValidator Control 

**Checks that the user's entry matches a pattern 
defined by a regular expression.**
### => The CustomValidator Control 

**Checks the user's entry 
using custom-coded validation logic.**
### =>The ValidationSummary Control 

**Displays a summary of all validation errors 
inline on a web page, in a message box, or both.**





