--CRIAR DB
CREATE DATABASE TUNISBRANDCO_DB
GO
--USAR DB
USE TUNISBRANDCO_DB
GO
--CRIAR TABELA DE CLIENTES
CREATE TABLE CLIENT(
    ID INT IDENTITY(1,1) NOT NULL,
    CPF VARCHAR(11) NOT NULL,
    CLIENT_NAME VARCHAR(100) NOT NULL,
    BIRTHDATE DATE NOT NULL,
    LOYALTY_POINTS DECIMAL DEFAULT 0,
    CONSTRAINT PK_CLIENT PRIMARY KEY (ID)
);
GO

SELECT * FROM CLIENT
GO

--CRIAR TABELA DE PRODUTOS
CREATE TABLE PRODUCT (
    ID INT IDENTITY(1,1) NOT NULL,
    PRICE DECIMAL(10,2) NOT NULL,
    EXPIRYDATE DATE NULL,
    PRODUCT_DESCRIPTION VARCHAR(100) NOT NULL,
    STOCK_QUANTITY INT NOT NULL,
    ISACTIVE BIT NOT NULL
    CONSTRAINT PK_PRODUCT PRIMARY KEY (ID)
)
GO

SELECT * FROM PRODUCT
GO

--CRIAR TABELA DE PEDIDOS
CREATE TABLE ORDERS(
    ID INT IDENTITY(1,1) NOT NULL,
    PRODUCT_ID INT NOT NULL,
    CLIENT_ID VARCHAR(11) NULL,
    CLIENT_NAME VARCHAR(100) NULL,
    PRODUCT_QUANTITY INT NOT NULL,
    TOTAL_PRICE DECIMAL(10,2) NOT NULL,
    ORDER_DATE DATETIME NOT NULL,
    ORDER_STATUS INT DEFAULT 1,
    CONSTRAINT PK_ORDER PRIMARY KEY (ID),
    CONSTRAINT FK_PRODUCT FOREIGN KEY (PRODUCT_ID) REFERENCES PRODUCT (ID)
);
GO

SELECT * FROM ORDERS
GO







