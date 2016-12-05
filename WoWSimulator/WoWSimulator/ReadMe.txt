For Help Developing This Project In asp.NET

0. The current method will not work because I haven't specified a connection string in SQL.cs, the static helper class that gets our data for us.
   Therefore, before you do anything, google up the connection string for mySQL and replace the connection string in that class with the appropriate one.
   To make sure that you're getting data, add a breakpoint right on the SQL.Run() function and use F10 to skip through to the other side. Check the DataTable
   Rows enumeration, then the ItemArray enumeration to see if you're getting data.

1. If data retrieval is not working with the listviews, change the column names in the backend to match the "Eval("COLUMN_NAME")" to match in the listview on the aspx page
2. I have an example of how to use the SQL retrieval method for populating listviews in default.aspx.cs commented in the second-ish function
3. I have an example of how to use the SQL retrieval method for populating labels in default.aspx.cs commented in the first-ish function