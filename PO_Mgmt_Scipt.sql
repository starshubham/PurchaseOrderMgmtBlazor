-- Creating ITEM_MASTER table
CREATE TABLE ITEM_MASTER (
    Code VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Unit VARCHAR(10) NOT NULL,
    Rate INT NOT NULL
);

-- Creating VENDOR_MASTER table
CREATE TABLE VENDOR_MASTER (
    Code VARCHAR(10) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

-- Creating PurchaseOrder table
CREATE TABLE PurchaseOrder (
    Code VARCHAR(10) NOT NULL PRIMARY KEY,
    DocDate DATE NOT NULL,
    VCode VARCHAR(10) NOT NULL,
    TotQuant INT NOT NULL,
    TotAmt INT NOT NULL,
    Comment VARCHAR(500) NULL,
    Remarks VARCHAR(500) NULL,
    FOREIGN KEY (VCode) REFERENCES VENDOR_MASTER(Code)
);

-- Creating PO_Item table
CREATE TABLE PO_Item (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ICode VARCHAR(10) NOT NULL,
    POCode VARCHAR(10) NOT NULL,
    IUnit VARCHAR(10) NOT NULL,
    Quantity INT NOT NULL,
    IRate INT NOT NULL,
    Amount INT NOT NULL,
    FOREIGN KEY (ICode) REFERENCES ITEM_MASTER(Code),
    FOREIGN KEY (POCode) REFERENCES PurchaseOrder(Code)
);

Insert into VENDOR_MASTER (Code, Name) values
('V001', 'Ram Pal'),
('V002', 'Shyam Mohan Singh'),
('V003', 'Shubham Verma'),
('V004', 'Shivam Singh'),
('V005', 'Abhishek Chaurasia')

Select * from VENDOR_MASTER

Insert into ITEM_MASTER (Code, Name, Unit, Rate) values
('1001', 'Mobile', 'Nos', 10000),
('1002', 'Laptop', 'Nos', 80000),
('1003', 'Watch', 'Nos', 2000),
('1004', 'Earphone', 'Nos', 1000),
('1005', 'EarBud', 'Nos', 2000)

Select * from ITEM_MASTER