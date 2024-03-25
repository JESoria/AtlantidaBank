USE [AtlantidaBank]
GO
/****** Object:  Table [dbo].[C_CardTypes]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_CardTypes](
	[CardTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
	[InterestRate] [decimal](18, 2) NOT NULL,
	[MinimumBalanceRate] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CardTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C_StatusCrediCards]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C_StatusCrediCards](
	[StatusCrediCardID] [int] IDENTITY(1,1) NOT NULL,
	[StatusCrediCard] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusCrediCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_CrediCards]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_CrediCards](
	[CrediCardId] [int] IDENTITY(1,1) NOT NULL,
	[CardTypeID] [int] NOT NULL,
	[StatusCrediCardID] [int] NOT NULL,
	[CardHolder] [varchar](25) NOT NULL,
	[CardNumber] [varchar](20) NOT NULL,
	[CurrentBalance] [decimal](18, 2) NOT NULL,
	[CreditLimit] [decimal](18, 2) NOT NULL,
	[BalanceAvailable] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CrediCardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_CrediCardUsers]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_CrediCardUsers](
	[CrediCardUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CrediCardId] [int] NOT NULL,
	[active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CrediCardUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[E_Users]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[E_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Transactions]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[CrediCardId] [int] NOT NULL,
	[TransactionType] [char](1) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[IPAddress] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[C_CardTypes] ON 

INSERT [dbo].[C_CardTypes] ([CardTypeID], [TypeName], [Description], [InterestRate], [MinimumBalanceRate]) VALUES (1, N'Tarjeta de Crédito Atlántida Cash', N'Tarjeta de Crédito Atlántida Cash', CAST(0.25 AS Decimal(18, 2)), CAST(0.05 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[C_CardTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[C_StatusCrediCards] ON 

INSERT [dbo].[C_StatusCrediCards] ([StatusCrediCardID], [StatusCrediCard], [Description]) VALUES (1, N'Activa', N'La tarjeta de credito puede utilizarse para transacciones')
INSERT [dbo].[C_StatusCrediCards] ([StatusCrediCardID], [StatusCrediCard], [Description]) VALUES (2, N'Inactiva', N'La tarjeta de credito no puede utilizarse para transacciones')
INSERT [dbo].[C_StatusCrediCards] ([StatusCrediCardID], [StatusCrediCard], [Description]) VALUES (3, N'Bloqueda', N'Se ha realizado bloqueo por algun motivo seguridad')
SET IDENTITY_INSERT [dbo].[C_StatusCrediCards] OFF
GO
SET IDENTITY_INSERT [dbo].[E_CrediCards] ON 

INSERT [dbo].[E_CrediCards] ([CrediCardId], [CardTypeID], [StatusCrediCardID], [CardHolder], [CardNumber], [CurrentBalance], [CreditLimit], [BalanceAvailable]) VALUES (1, 1, 1, N'Eduardo Soria', N'3411-2224-4444-5585', CAST(349.84 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(1150.16 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[E_CrediCards] OFF
GO
SET IDENTITY_INSERT [dbo].[E_CrediCardUsers] ON 

INSERT [dbo].[E_CrediCardUsers] ([CrediCardUserID], [UserId], [CrediCardId], [active]) VALUES (1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[E_CrediCardUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[E_Users] ON 

INSERT [dbo].[E_Users] ([UserId], [FirstName], [LastName], [Email], [Username], [Password], [active]) VALUES (1, N'José Eduardo', N'Guevara Soria', N'ing_soria@hotmail.com', N'jsoria', N'Ç­DË­v*] ¤RùèTýÁàç¥*8_#óê±Ø“ÔrcMúÇÓN¼5Ñj·ûŠÈ—QÖÇSÆØÞwì', 1)
SET IDENTITY_INSERT [dbo].[E_Users] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Transactions] ON 

INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (19, 1, N'C', CAST(N'2024-02-01T00:00:00.000' AS DateTime), N'Deku Figure My Hero Academy', CAST(56.00 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (20, 1, N'C', CAST(N'2024-03-10T00:00:00.000' AS DateTime), N'Uraraka Figure My Hero Academy', CAST(56.00 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (21, 1, N'C', CAST(N'2024-03-11T00:00:00.000' AS DateTime), N'Froppy Figure My Hero Academy', CAST(56.00 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (22, 1, N'C', CAST(N'2024-03-12T00:00:00.000' AS DateTime), N'Son Goku', CAST(75.00 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (23, 1, N'C', CAST(N'2024-03-22T00:00:00.000' AS DateTime), N'Mouse Gamer', CAST(84.50 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (24, 1, N'C', CAST(N'2024-03-22T00:00:00.000' AS DateTime), N'GTA San Adreas Game', CAST(54.36 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (25, 1, N'C', CAST(N'2024-03-22T00:00:00.000' AS DateTime), N'Keyboard Gamer', CAST(25.50 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (26, 1, N'C', CAST(N'2024-03-22T00:00:00.000' AS DateTime), N'Battle Pass Fornite Epic Games', CAST(9.99 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (27, 1, N'C', CAST(N'2024-03-23T00:00:00.000' AS DateTime), N'Mouse Pad', CAST(16.00 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (28, 1, N'P', CAST(N'2024-03-23T00:00:00.000' AS DateTime), N'Pago de tarjeta', CAST(150.00 AS Decimal(18, 2)), N'190.150.219.231')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (29, 1, N'C', CAST(N'2024-03-24T22:11:00.000' AS DateTime), N'Mario Kart Game', CAST(41.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (30, 1, N'C', CAST(N'2024-03-24T22:13:00.000' AS DateTime), N'Wallmart', CAST(78.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (31, 1, N'C', CAST(N'2024-03-24T22:23:00.000' AS DateTime), N'Bocinas Gamer', CAST(55.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (32, 1, N'C', CAST(N'2024-03-24T22:24:00.000' AS DateTime), N'Camisa Polo Talla M Almacenes Siman', CAST(21.50 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (33, 1, N'C', CAST(N'2024-03-24T22:27:00.000' AS DateTime), N'Pantalón Talla 34 ', CAST(35.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (34, 1, N'C', CAST(N'2024-03-24T22:27:00.000' AS DateTime), N'Pantalón Talla 34 ', CAST(35.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (35, 1, N'C', CAST(N'2024-03-24T22:37:00.000' AS DateTime), N'Cuadro de Dragon Ball Z', CAST(23.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (36, 1, N'C', CAST(N'2024-03-24T22:37:00.000' AS DateTime), N'Cuadro de Dragon Ball Z', CAST(23.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (37, 1, N'C', CAST(N'2024-03-24T22:37:00.000' AS DateTime), N'Cuadro de Dragon Ball Z', CAST(23.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (38, 1, N'C', CAST(N'2024-03-25T00:08:00.000' AS DateTime), N'Burger King Wopper JR', CAST(63.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (39, 1, N'P', CAST(N'2024-03-25T00:09:00.000' AS DateTime), N'Realización de pago', CAST(100.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (40, 1, N'P', CAST(N'2024-03-25T00:10:00.000' AS DateTime), N'Realización de pago', CAST(150.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (41, 1, N'C', CAST(N'2024-03-25T11:26:00.000' AS DateTime), N'China Wok Combo para 4', CAST(54.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (42, 1, N'P', CAST(N'2024-03-25T11:27:00.000' AS DateTime), N'Realización de pago', CAST(50.00 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (43, 1, N'C', CAST(N'2024-03-25T11:38:00.000' AS DateTime), N'Figura de Pokemon Pikachu', CAST(36.99 AS Decimal(18, 2)), N'::1')
INSERT [dbo].[T_Transactions] ([TransactionId], [CrediCardId], [TransactionType], [TransactionDate], [Description], [Amount], [IPAddress]) VALUES (44, 1, N'P', CAST(N'2024-03-25T11:38:00.000' AS DateTime), N'Realización de pago', CAST(122.00 AS Decimal(18, 2)), N'::1')
SET IDENTITY_INSERT [dbo].[T_Transactions] OFF
GO
ALTER TABLE [dbo].[E_CrediCards]  WITH CHECK ADD  CONSTRAINT [fk_CardTypes_CrediCards] FOREIGN KEY([CardTypeID])
REFERENCES [dbo].[C_CardTypes] ([CardTypeID])
GO
ALTER TABLE [dbo].[E_CrediCards] CHECK CONSTRAINT [fk_CardTypes_CrediCards]
GO
ALTER TABLE [dbo].[E_CrediCards]  WITH CHECK ADD  CONSTRAINT [fk_StatusCrediCardID_CrediCards] FOREIGN KEY([StatusCrediCardID])
REFERENCES [dbo].[C_StatusCrediCards] ([StatusCrediCardID])
GO
ALTER TABLE [dbo].[E_CrediCards] CHECK CONSTRAINT [fk_StatusCrediCardID_CrediCards]
GO
ALTER TABLE [dbo].[E_CrediCardUsers]  WITH CHECK ADD  CONSTRAINT [fk_CrediCards_CrediCardUsers] FOREIGN KEY([CrediCardId])
REFERENCES [dbo].[E_CrediCards] ([CrediCardId])
GO
ALTER TABLE [dbo].[E_CrediCardUsers] CHECK CONSTRAINT [fk_CrediCards_CrediCardUsers]
GO
ALTER TABLE [dbo].[E_CrediCardUsers]  WITH CHECK ADD  CONSTRAINT [fk_Users_CrediCardUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[E_Users] ([UserId])
GO
ALTER TABLE [dbo].[E_CrediCardUsers] CHECK CONSTRAINT [fk_Users_CrediCardUsers]
GO
ALTER TABLE [dbo].[T_Transactions]  WITH CHECK ADD  CONSTRAINT [fk_CrediCards_Transactions] FOREIGN KEY([CrediCardId])
REFERENCES [dbo].[E_CrediCards] ([CrediCardId])
GO
ALTER TABLE [dbo].[T_Transactions] CHECK CONSTRAINT [fk_CrediCards_Transactions]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddPurchase]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddPurchase]
    @CrediCardId INT,
    @TransactionDate DATETIME,
    @Description VARCHAR(150),
    @Amount DECIMAL(18, 2),
    @IPAddress VARCHAR(45)
AS
BEGIN
    BEGIN TRY
        -- Insertar la nueva compra en la tabla T_Transactions
        INSERT INTO T_Transactions (CrediCardId, TransactionDate, Description, Amount, TransactionType, IPAddress)
        VALUES (@CrediCardId, @TransactionDate, @Description, @Amount, 'C', @IPAddress);

        -- Devolver un mensaje de éxito
        SELECT 'Compra agregada exitosamente.' AS Message;
    END TRY
    BEGIN CATCH
        -- Devolver un mensaje de error en caso de que ocurra una excepción
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CalculateBonifiableInterest]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CalculateBonifiableInterest]
    @CrediCardId INT
AS
BEGIN
    DECLARE @BonifiableInterest DECIMAL(18, 2);
    DECLARE @TotalBalance DECIMAL(18, 2);
    DECLARE @InterestRate DECIMAL(5, 2); -- Porcentaje Interés Configurable

    -- Obtener el saldo total de la tarjeta de crédito
    SELECT @TotalBalance = CurrentBalance
    FROM E_CrediCards
    WHERE CrediCardId = @CrediCardId;

    -- Obtener el porcentaje de interés configurable
    SELECT @InterestRate = InterestRate
    FROM C_CardTypes
    WHERE CardTypeId = (
        SELECT CardTypeId
        FROM E_CrediCards
        WHERE CrediCardId = @CrediCardId
    );

    -- Calcular el Interés Bonificable
    SET @BonifiableInterest = @TotalBalance * @InterestRate;

    -- Devolver el Interés Bonificable
    SELECT @BonifiableInterest AS BonifiableInterest;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CalculateMinimumPayment]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CalculateMinimumPayment]
    @CrediCardId INT
AS
BEGIN
    DECLARE @TotalBalance DECIMAL(18, 2);
    DECLARE @MinimumBalanceRate DECIMAL(18, 2);
    DECLARE @MinimumPayment DECIMAL(18, 2);

    SELECT 
        @TotalBalance = EC.CurrentBalance,
        @MinimumBalanceRate = CT.MinimumBalanceRate
    FROM 
        E_CrediCards EC
    INNER JOIN
        C_CardTypes CT ON EC.CardTypeID = CT.CardTypeID
    WHERE
        EC.CrediCardId = @CrediCardId;

    SET @MinimumPayment = @TotalBalance * @MinimumBalanceRate;

    SELECT @MinimumPayment AS MinimumPayment;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CalculateTotalAmountToPay]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CalculateTotalAmountToPay]
    @CrediCardId INT
AS
BEGIN
    DECLARE @TotalBalance DECIMAL(18, 2);
    DECLARE @TotalAmountToPay DECIMAL(18, 2);

    -- Obtener el saldo actual de la tarjeta
    SELECT 
        @TotalBalance = CurrentBalance
    FROM 
        E_CrediCards
    WHERE
        CrediCardId = @CrediCardId;

    -- Calcular el monto total a pagar
    SET @TotalAmountToPay = @TotalBalance;

    -- Devolver el monto total a pagar
    SELECT @TotalAmountToPay AS TotalAmountToPay;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAccountStatementDetail]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAccountStatementDetail]
@UserId INT = 0, @CrediCardId INT = 0
AS
BEGIN
    SELECT
		EC.CrediCardId,
        EC.CardHolder,
        EC.CardNumber,
        EC.CurrentBalance,
        EC.CreditLimit,
        EC.BalanceAvailable
    FROM
        E_CrediCards EC
			INNER JOIN E_CrediCardUsers CC ON CC.CrediCardId = EC.CrediCardId
    WHERE
        CC.UserId = 1 AND EC.CardTypeID = @CrediCardId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllTransactionsForCreditCard]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllTransactionsForCreditCard]
    @CreditCardId INT
AS
BEGIN
    DECLARE @CurrentMonth INT;

    -- Obtener el mes actual
    SET @CurrentMonth = MONTH(GETDATE());

    -- Seleccionar todas las transacciones para la tarjeta de crédito especificada en el mes actual
    SELECT TransactionId, TransactionDate, Description, Amount, TransactionType
    FROM T_Transactions
    WHERE CrediCardId = @CreditCardId
    AND MONTH(TransactionDate) = @CurrentMonth
    ORDER BY TransactionDate DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCurrentMonthPurchases]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCurrentMonthPurchases]
@CrediCardId INT = 0
AS
BEGIN
    DECLARE @fechaInicioMesActual DATETIME;
    DECLARE @fechaFinMesActual DATETIME;
    SET @fechaInicioMesActual = DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0);
    SET @fechaFinMesActual = DATEADD(day, -1, DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0));

    SELECT
        TransactionDate,
        Description,
        Amount
    FROM
        T_Transactions
    WHERE
        CrediCardId = @CrediCardId
        AND TransactionType = 'C' -- Compras
        AND TransactionDate BETWEEN @fechaInicioMesActual AND @fechaFinMesActual;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalPurchases]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTotalPurchases]
    @CrediCardId INT
AS
BEGIN
    DECLARE @CurrentMonth INT;
    DECLARE @PreviousMonth INT;

    -- Obtener el número de mes actual
    SET @CurrentMonth = MONTH(GETDATE());

    -- Obtener el número de mes anterior
    SET @PreviousMonth = MONTH(DATEADD(MONTH, -1, GETDATE()));

    -- Obtener el monto total de compras del mes actual
    DECLARE @TotalCurrentMonth DECIMAL(18, 2);
    SELECT @TotalCurrentMonth = SUM(Amount)
    FROM T_Transactions
    WHERE TransactionType = 'C' -- Compras
    AND CrediCardId = @CrediCardId
    AND MONTH(TransactionDate) = @CurrentMonth;

    -- Obtener el monto total de compras del mes anterior
    DECLARE @TotalPreviousMonth DECIMAL(18, 2);
    SELECT @TotalPreviousMonth = SUM(Amount)
    FROM T_Transactions
    WHERE TransactionType = 'C' -- Compras
    AND CrediCardId = @CrediCardId
    AND MONTH(TransactionDate) = @PreviousMonth;

    -- Devolver los resultados
    SELECT @TotalCurrentMonth AS TotalCurrentMonthPurchases, @TotalPreviousMonth AS TotalPreviousMonthPurchases;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Login]
@username varchar(200), 
@password varchar(200)
as 	
begin
	SELECT TOP 1 
		US.UserId,
		US.FirstName,
		US.LastName,
		US.Email,
		C.CrediCardId
	FROM E_Users US 
		INNER JOIN E_CrediCardUsers CC ON CC.UserId = US.UserId
		INNER JOIN E_CrediCards C ON C.CrediCardId = CC.CrediCardId
	WHERE 
		US.Username = @username
		AND US.Password = HASHBYTES('SHA2_512', @password)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MakePayment]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MakePayment]
    @CrediCardId INT,
    @TransactionDate DATETIME,
    @Description VARCHAR(150),
    @Amount DECIMAL(18, 2),
    @IPAddress VARCHAR(45)
AS
BEGIN
    BEGIN TRY
        -- Insertar el pago en la tabla T_Transactions
        INSERT INTO T_Transactions (CrediCardId, TransactionDate, Amount, TransactionType, Description, IPAddress)
        VALUES (@CrediCardId, @TransactionDate, @Amount, 'P', @Description, @IPAddress);

        -- Devolver un mensaje de éxito
        SELECT 'Pago realizado exitosamente.' AS Message;
    END TRY
    BEGIN CATCH
        -- Devolver un mensaje de error en caso de que ocurra una excepción
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TotalCashAmountToPayWithInterest]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_TotalCashAmountToPayWithInterest]
    @CrediCardId INT
AS
BEGIN
    DECLARE @TotalBalance DECIMAL(18, 2);
    DECLARE @InterestBonificable DECIMAL(18, 2);
    DECLARE @TotalCashAmountToPayWithInterest DECIMAL(18, 2);

    SELECT 
        @TotalBalance = CurrentBalance
    FROM 
        E_CrediCards
    WHERE
        CrediCardId = @CrediCardId;

    SELECT 
        @InterestBonificable = @TotalBalance * (SELECT InterestRate FROM C_CardTypes WHERE CardTypeID = (SELECT CardTypeID FROM E_CrediCards WHERE CrediCardId = @CrediCardId));

    SET @TotalCashAmountToPayWithInterest = @TotalBalance + @InterestBonificable;

    SELECT @TotalCashAmountToPayWithInterest AS TotalCashAmountToPayWithInterest;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Password]    Script Date: 25/03/2024 11:43:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_Password]
		@UserId int,
		@NewPassword varchar(150)
AS
BEGIN
	UPDATE E_Users 
		SET Password =  HASHBYTES('SHA2_512', @NewPassword)
	WHERE UserId = @UserId

	SELECT
		US.UserId,
		US.Email
	FROM E_Users US
	WHERE US.UserId = @UserId	
END
GO
