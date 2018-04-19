use AdventureWorks2012


--Creates the user and assigns the role
CREATE LOGIN AdvWorks2012 
WITH PASSWORD = '1234';

CREATE USER AdvWorks2012 FOR LOGIN AdvWorks2012;
GO

ALTER ROLE db_datareader ADD MEMBER AdvWorks2012;
GO

ALTER ROLE db_datawriter ADD MEMBER AdvWorks2012;


--Denies Access to HumanResource Schema
DENY SELECT ON SCHEMA::
	HumanResources
		TO AdvWorks2012;

DENY ALTER ON SCHEMA::
	HumanResources
		TO AdvWorks2012;

DENY INSERT ON SCHEMA::
	HumanResources
		TO AdvWorks2012;

DENY UPDATE ON SCHEMA::
	HumanResources
		TO AdvWorks2012;

DENY DELETE ON SCHEMA::
	HumanResources
		TO AdvWorks2012;

		
--Denies write access to Person Schema
DENY ALTER ON SCHEMA::
	Person
		TO AdvWorks2012;

DENY INSERT ON SCHEMA::
	Person
		TO AdvWorks2012;

DENY UPDATE ON SCHEMA::
	Person
		TO AdvWorks2012;

DENY DELETE ON SCHEMA::
	Person
		TO AdvWorks2012;