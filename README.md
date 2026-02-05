# B2B Procurement & Order Management Platform

// 🔐 Identity & Authorization
Table Users {
  Id int [pk]
  Email varchar
  PasswordHash varchar
  IsActive boolean
  CreatedAt timestamp
}

Table Roles {
  Id int [pk]
  Name varchar
}

Table UserRoles {
  UserId int [ref: > Users.Id]
  RoleId int [ref: > Roles.Id]
  Indexes {
    (UserId, RoleId) [unique]
  }
}

// 🏢 Business Customers & Suppliers
Table BusinessCustomers {
  Id int [pk]
  CompanyName varchar
  ContactEmail varchar
  CreditLimit decimal
}

Table Suppliers {
  Id int [pk]
  Name varchar
  ContactEmail varchar
  IsActive boolean
}

// 📦 Product & Catalog
Table Products {
  Id int [pk]
  Name varchar
  Category varchar
  SupplierId int [ref: > Suppliers.Id]
  Status varchar
  CreatedAt timestamp
}

// 🏬 Warehouses & Inventory
Table Warehouses {
  Id int [pk]
  Name varchar
  Location varchar
}

Table Inventory {
  Id int [pk]
  ProductId int [ref: > Products.Id]
  WarehouseId int [ref: > Warehouses.Id]
  QuantityAvailable int
  QuantityReserved int
}

Table InventoryLogs {
  Id int [pk]
  ProductId int [ref: > Products.Id]
  WarehouseId int [ref: > Warehouses.Id]
  ActionType varchar
  QuantityChanged int
  PreviousQuantity int
  NewQuantity int
  PerformedByUserId int [ref: > Users.Id]
  CreatedAt timestamp
}

// 🛒 Orders & Order Lifecycle
Table Orders {
  Id int [pk]
  BusinessCustomerId int [ref: > BusinessCustomers.Id]
  Status varchar
  TotalAmount decimal
  CreatedAt timestamp
}

Table OrderItems {
  Id int [pk]
  OrderId int [ref: > Orders.Id]
  ProductId int [ref: > Products.Id]
  Quantity int
  UnitPrice decimal
}

// ⏳ Inventory Reservations
Table InventoryReservations {
  Id int [pk]
  OrderId int [ref: > Orders.Id]
  ProductId int [ref: > Products.Id]
  WarehouseId int [ref: > Warehouses.Id]
  Quantity int
  ExpiresAt timestamp
  Status varchar
}

// 💳 P
