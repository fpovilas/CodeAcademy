SELECT
	Account.Number,
	Bank.Bank,
	Person.FirstName
FROM
	Account
JOIN
	Bank ON Account.BankID = Bank.ID_PK
JOIN
	Person ON Account.PersonID = Person.PK_ID
WHERE
	Person.FirstName = 'Antanas'
	AND
	Account.AmountOfMoney > 1000;

