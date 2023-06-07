USE MyCompany

INSERT INTO Customer ([CustomerId], [FirstName], [LastName], [Company], [Created])
VALUES
( '{f102c51c-fc65-7173-3cc0-fdc51ad91b88}', N'Angelica', N'Contreras', N'Qwisapedex International Group', N'2000-08-20T00:59:11.9' ), 
( '{b1965eb0-7bdc-b902-a364-fe1db6ec466c}', N'Angela', N'Davis', N'Suprobazz International Company', N'1981-09-08T12:25:00.63' ), 
( '{ef2fe221-17be-29d8-1488-fe287b1026fc}', N'Tammie', N'Graves', N'Klitanistor WorldWide ', N'1955-09-21T05:18:13.08' ), 
( '{73cbf3e2-946c-f43b-fe1f-fe389344d18e}', N'Edith', N'Wallace', N'Surdimantor  Group', N'1987-09-23T03:21:37.08' ), 
( '{de24dfab-e6d8-1bb6-f15c-fe52928b4017}', N'Duane', N'Walters', N'Emvenupin  Company', N'1975-04-26T19:35:26.21' ), 
( '{e87c328b-5d85-f469-aa18-feb00de1b356}', N'Maggie', N'Day', N'Tipfropanicator WorldWide ', N'2010-01-29T23:27:28.21' ), 
( '{daf5a3ef-8ceb-5943-2494-feed0531be73}', N'Felix', N'Aguirre', N'Klicador  Inc', N'1983-06-30T01:25:48.28' ), 
( '{3df7d613-77ee-f6f9-53a8-ff08a7bffb7f}', N'Danielle', N'Villegas', N'Unrobex International ', N'2019-12-12T02:13:30.59' ), 
( '{b0c85e23-f239-e644-33f3-ff0a990233b9}', N'Angelo', N'Mahoney', N'Zeenipinistor Direct Company', N'1999-10-25T05:10:55.24' ), 
( '{93147583-5237-ada6-708f-ffa3195e12b4}', N'Jackie', N'Turner', N'Parnipex  ', N'2000-09-26T23:42:12' )

INSERT INTO Item ([ItemId], [Name], [Price], [Created])
VALUES
( '{18b5769f-125d-4f42-888e-27a95cd7dc2b}', N'Item 5', 59.99, N'2023-04-06T15:53:22.903' ), 
( '{de9196e5-8ffa-46ad-b498-61f9f5b87e87}', N'Item 2', 29.99, N'2023-04-06T15:53:22.903' ), 
( '{d31acba5-7e39-4f1e-99f2-9ba1ff985b0d}', N'Item 4', 49.99, N'2023-04-06T15:53:22.903' ), 
( '{55ca87d6-b8d4-4fa6-bd92-ac6229052f54}', N'Item 3', 39.99, N'2023-04-06T15:53:22.903' ), 
( '{e93a3773-fc6f-4ce4-bff1-d388fcd28cb8}', N'Item 1', 19.99, N'2023-04-06T15:53:22.903' )

INSERT INTO dbo.Invoice (
    InvoiceId,
    CustomerId,
    Reference,
    Total,
    Created
)
VALUES
(   'd5277c15-9672-4e70-ab8f-adf4cc69afa8',   -- InvoiceId - uniqueidentifier
    'f102c51c-fc65-7173-3cc0-fdc51ad91b88',   -- CustomerId - uniqueidentifier
    N'000000001',    -- Reference - nvarchar(255)
    19.99,   -- Total - decimal(18, 2)
    DEFAULT -- Created - datetime
    )

INSERT INTO InvoiceItem ([InvoiceItemId], [InvoiceId], [ItemId], [Quantity], [Created])
VALUES
( '{40cfa695-9e0d-42e6-ae5d-d7dbc198b8d3}', '{d5277c15-9672-4e70-ab8f-adf4cc69afa8}', '{e93a3773-fc6f-4ce4-bff1-d388fcd28cb8}', 1, N'2023-04-06T15:56:45.69' )

INSERT INTO dbo.Invoice (
    InvoiceId,
    CustomerId,
    Reference,
    Total,
    Created
)
VALUES
(   '{CB8AFC3F-8A59-4CCC-B487-DBC929DF3A2B}',   -- InvoiceId - uniqueidentifier
    '{daf5a3ef-8ceb-5943-2494-feed0531be73}',   -- CustomerId - uniqueidentifier
    N'000000002',    -- Reference - nvarchar(255)
    99.98,   -- Total - decimal(18, 2)
    DEFAULT -- Created - datetime
    )

INSERT INTO InvoiceItem ([InvoiceItemId], [InvoiceId], [ItemId], [Quantity], [Created])
VALUES
( '{F022439E-2269-418D-993B-D02553D7E618}', '{CB8AFC3F-8A59-4CCC-B487-DBC929DF3A2B}', '{18b5769f-125d-4f42-888e-27a95cd7dc2b}', 1, N'2023-04-06T15:56:45.69' ),
( '{50DCC89D-DA95-4911-B50B-8F21B69795AC}', '{CB8AFC3F-8A59-4CCC-B487-DBC929DF3A2B}', '{55ca87d6-b8d4-4fa6-bd92-ac6229052f54}', 1, N'2023-04-06T15:56:45.69' )