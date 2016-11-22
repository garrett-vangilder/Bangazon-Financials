CREATE TABLE "Customer"
(
	"CustomerId" INTEGER PRIMARY KEY,
	"FirstName" text NOT NULL,
	"LastName" text NOT NULL,
	"StreetNumber" integer NOT NULL,
	"StreetName" text NOT NULL,
	"ZipCode" integer NOT NULL,
	"State" text NOT NULL
);


CREATE TABLE "Order"
(
	"OrderId" INTEGER PRIMARY KEY,
	"CustomerId" INTEGER NOT NULL,
	"DateCompleted" datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S')),
	FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
);

CREATE TABLE "Product"
(
	"ProductId" INTEGER PRIMARY KEY,
	"Price" INTEGER NOT NULL
);

CREATE TABLE "LineItem"
(
	"LineItemId" INTEGER PRIMARY KEY,
	"ProductId" INTEGER NOT NULL,
	"OrderId" INTEGER NOT NULL,
	FOREIGN KEY ("ProductId") REFERENCES "Product" ("ProductId"),
	FOREIGN KEY ("OrderId") REFERENCES "Order" ("OrderId")
);