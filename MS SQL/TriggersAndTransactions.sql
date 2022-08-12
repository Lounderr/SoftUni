USE Bank;

CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum DECIMAL(10, 2) NOT NULL,
	NewSum DECIMAL(10, 2) NOT NULL
);

GO

CREATE TRIGGER tr_AddToLogsOnAccountUpdate 
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted i
		JOIN deleted d ON i.Id = d.Id
END

GO

UPDATE Accounts 
	SET Balance = 153.12
	WHERE Id = 1

SELECT * FROM Logs

-- # 

CREATE TABLE NotificationEmails (
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	[Subject] NVARCHAR(500) NOT NULL,
	Body NVARCHAR(500) NOT NULL
);

GO

CREATE OR ALTER TRIGGER tr_SendEmailOnLogEntry
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
		SELECT 
			AccountId, 
			CONCAT('Balance change for account: ', AccountId),
			CONCAT('On ', getdate(), ' your balance was changed from ', i.OldSum, ' to ', i.NewSum)
	FROM inserted i
END
GO

UPDATE Accounts 
	SET Balance = 153.12
	WHERE Id = 1

SELECT * FROM NotificationEmails
SELECT * FROM Logs

GO

-- #

CREATE OR ALTER PROC sp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(10, 4))
AS
BEGIN
	IF @MoneyAmount > 0
	UPDATE Accounts
		SET Balance = Balance + @MoneyAmount
		WHERE Id = @AccountId
END

GO

EXEC sp_DepositMoney 1, 10
SELECT * FROM Accounts where Id = 1

GO

-- #

CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(10, 4)) 
AS
BEGIN
	IF @MoneyAmount > 0
	UPDATE Accounts
		SET Balance = Balance - @MoneyAmount
		WHERE Id = @AccountId
END

GO

EXEC usp_WithdrawMoney 5, 25
SELECT * FROM Accounts where Id = 5

GO

-- #

CREATE OR ALTER PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(10, 4))
AS
BEGIN TRANSACTION
	IF @Amount <= 0 
	BEGIN
		ROLLBACK;
		THROW 50001, 'Amount has to be a positive number.', 1
	END

	IF @Amount > (SELECT Balance FROM Accounts WHERE Id = @SenderId)
	BEGIN
		ROLLBACK;
		THROW 50002, 'Insufficient funds.', 1
	END

	UPDATE Accounts
		SET Balance = Balance - @Amount
		WHERE Id = @SenderId 

	UPDATE Accounts
		SET Balance = Balance + @Amount
		WHERE Id = @ReceiverId
COMMIT

EXEC usp_TransferMoney 1, 2, 50000

GO

-- #

-- Part 2