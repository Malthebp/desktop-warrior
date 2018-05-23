DROP TABLE IF EXISTS dg_ProductLogs
CREATE TABLE dg_ProductLogs
(
	ProductLogId INT IDENTITY(1,1),
	ProductId INT,
	CurrentSqlUser NVARCHAR(100),
	SqlAction NVARCHAR(25),
	Created DATETIME,
	PRIMARY KEY (ProductLogId)
)


CREATE TRIGGER ProductLogTrigger 
ON dg_Products
AFTER INSERT, UPDATE, DELETE
AS 
BEGIN 

    DECLARE @action as char(1);
	DECLARE @Id as INT
    SET @action = 'I'; -- Set Action to Insert by default.
	SET @Id = (Select ProductId from inserted) 
    IF EXISTS(SELECT * FROM DELETED)
    BEGIN
        SET @action = 
            CASE
                WHEN EXISTS(SELECT * FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.       
            END
		SET @Id = (Select ProductId from deleted)
    END

	INSERT INTO dg_ProductLogs (ProductId, CurrentSqlUser, SqlAction, Created) VALUES (@Id, CURRENT_USER, @action, CURRENT_TIMESTAMP);
END
