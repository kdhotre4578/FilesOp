# FilesOp
Recursively copies files from source location to destination along with subfolders and their files. Displays the copy progress on UI.
--------------------------------------------------------------------------------------------------------------------
Project Highlights -

 - 2 TIER Architecture - Client UI and Business layer.
 - Asynchronously calls business layer functionality to separate out UI thread from processing.
 - BLayer Unit tested. (Contains both positive and negative scenarios)
 - BLayer assembly can be plugged in ( reusable ) with other windows or web applications.
 - Along with processing, the BLayer provides the copy statuses to the Client.
   e.g. Validations, File Count or Copy status. Client only needs to display them.

--------------------------------------------------------------------------------------------------------------------
Application structure:

FilesOp
- Contains UI
- Asyncronously calls BLayer Processing methods
- Displays copy progress 

FilesOp.BLayer
- Contains File and Folder Copy Logic (Recursive)
- Contains Validation, copied file count and returning copy status description functionality.

FilesOp.Test
- Contains Unit Tests (Contains both positive and negative scenarios)
- Utilised NUnit framework for unit testing.

--------------------------------------------------------------------------------------------------------------------
Technologies:

- Programming Language : C#
- FrontEnd : Windows Form
- Test Framework : NUnit
- .Net Framework : 4.7

--------------------------------------------------------------------------------------------------------------------
*Note : Will be adding more new features/functionalities in near future.
