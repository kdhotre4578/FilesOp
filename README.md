# FilesOp
FilesOp project (initial version)  

Current Key Project Highlights :  
1. Recursive Files Copy logic from source location to destination.  Copies all subfolders and its files. Displays the copy progress on UI.
2. 2 TIER Architecture - Client and Business layer.  
3. Asynchronously calls business layer functionality to separate out UI thread from processing. 
4. BLayer Unit tested. (Contains both positive and negative scenarios) 
5. BLayer can be plugged in ( reusable ) with other windows or web applications.   
6. Along with processing, the BLayer provides the copy statuses to the Client.  
e.g. Validations, File Count or Copy status. Client only needs to display them.
