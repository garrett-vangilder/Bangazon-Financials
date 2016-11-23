CREATE TABLE "Customer"
(
	"CustomerId" INTEGER PRIMARY KEY,
	"FirstName" text NOT NULL,
	"LastName" text NOT NULL,
	"StreetNumber" text NOT NULL,
	"StreetName" text NOT NULL,
	"ZipCode" integer NOT NULL,
	"State" text NOT NULL
);


CREATE TABLE "CustomerOrder"
(
	"CustomerOrderId" INTEGER PRIMARY KEY,
	"CustomerId" INTEGER NOT NULL,
	"DateCompleted" datetime NOT NULL DEFAULT(strftime('%Y-%m-%d %H:%M:%S')),
	FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("CustomerId")
);

CREATE TABLE "Product"
(
	"ProductId" INTEGER PRIMARY KEY,
	"Name" text NOT NULL,
	"Price" INTEGER NOT NULL,
	"Revenue" INTEGER NOT NULL
);

CREATE TABLE "LineItem"
(
	"LineItemId" INTEGER PRIMARY KEY,
	"ProductId" INTEGER NOT NULL,
	"CustomerOrderId" INTEGER NOT NULL,
	FOREIGN KEY ("ProductId") REFERENCES "Product" ("ProductId"),
	FOREIGN KEY ("CustomerOrderId") REFERENCES "CustomerOrder" ("CustomerOrderId")
);