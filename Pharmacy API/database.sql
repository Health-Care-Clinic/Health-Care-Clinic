CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Medicines" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NULL,
    "Quantity" integer NOT NULL,
    CONSTRAINT "PK_Medicines" PRIMARY KEY ("Id")
);

INSERT INTO "Medicines" ("Id", "Name", "Quantity")
VALUES (1, 'Brufen', 400);
INSERT INTO "Medicines" ("Id", "Name", "Quantity")
VALUES (2, 'Klacid', 200);
INSERT INTO "Medicines" ("Id", "Name", "Quantity")
VALUES (3, 'Paracetamol', 250);

SELECT setval(
    pg_get_serial_sequence('"Medicines"', 'Id'),
    GREATEST(
        (SELECT MAX("Id") FROM "Medicines") + 1,
        nextval(pg_get_serial_sequence('"Medicines"', 'Id'))),
    false);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211104102948_FirstMigration', '5.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE "ApiKeys" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NULL,
    "Key" text NULL,
    "BaseUrl" text NULL,
    CONSTRAINT "PK_ApiKeys" PRIMARY KEY ("Id")
);

CREATE TABLE "Messages" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Sender" text NULL,
    "MessageText" text NULL,
    "Receiver" text NULL,
    CONSTRAINT "PK_Messages" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211104103944_SecondMigration', '5.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "ApiKeys" ADD "Category" text NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211105163508_ThirdMigration', '5.0.11');

COMMIT;

START TRANSACTION;

CREATE TABLE "FeedbackReplies" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Text" text NULL,
    "SenderId" integer NOT NULL,
    "ReceiverId" integer NOT NULL,
    "TimeOfSending" timestamp without time zone NOT NULL,
    "FeedbackId" integer NOT NULL,
    CONSTRAINT "PK_FeedbackReplies" PRIMARY KEY ("Id")
);

CREATE TABLE "Feedbacks" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Text" text NULL,
    "SenderId" integer NOT NULL,
    "ReceiverId" integer NOT NULL,
    "TimeOfSending" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Feedbacks" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211105184653_FourthMigration', '5.0.11');

COMMIT;

START TRANSACTION;

ALTER TABLE "Medicines" ADD "CompatibileMedicine" text NULL;

ALTER TABLE "Medicines" ADD "Manufacturer" text NULL;

ALTER TABLE "Medicines" ADD "Reactions" text NULL;

ALTER TABLE "Medicines" ADD "SideEffects" text NULL;

ALTER TABLE "Medicines" ADD "Usage" text NULL;

ALTER TABLE "Medicines" ADD "Weight" integer NOT NULL DEFAULT 0;

UPDATE "Medicines" SET "CompatibileMedicine" = 'Aspirin', "Manufacturer" = 'Bayer', "Reactions" = 'Headache', "SideEffects" = 'Rash, Stomach pain', "Usage" = 'Pain relief', "Weight" = 400
WHERE "Id" = 1;

UPDATE "Medicines" SET "CompatibileMedicine" = 'Aspirin', "Manufacturer" = 'Bayer', "Reactions" = 'Headache, Swelling', "SideEffects" = 'Rash, Unconsciousness', "Usage" = 'Lung infections, Bronchitis', "Weight" = 500
WHERE "Id" = 2;

UPDATE "Medicines" SET "CompatibileMedicine" = 'Aspirin', "Manufacturer" = 'Galenika', "Reactions" = 'None', "SideEffects" = 'None', "Usage" = 'Toothache, Headache', "Weight" = 500
WHERE "Id" = 3;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211211173504_FifthMigration', '5.0.11');

COMMIT;

