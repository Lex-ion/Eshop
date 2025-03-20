-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost
-- Vytvořeno: Čtv 20. bře 2025, 20:22
-- Verze serveru: 10.3.25-MariaDB-0+deb10u1
-- Verze PHP: 5.6.36-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `4b2_urbantomas_db1`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `tbAccounts`
--

CREATE TABLE `tbAccounts` (
  `ID` int(11) NOT NULL,
  `AccountType` int(11) NOT NULL,
  `NAME` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Surname` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Adress` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Mail` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Password` varchar(128) COLLATE utf8_czech_ci NOT NULL,
  `RegistrationDate` datetime NOT NULL,
  `LastLogin` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbAccounts`
--

INSERT INTO `tbAccounts` (`ID`, `AccountType`, `NAME`, `Surname`, `Adress`, `Mail`, `Password`, `RegistrationDate`, `LastLogin`) VALUES
(1, 2, 'Jan', 'Novák', 'tamKdeBydlim 11/65', 'novakJan@sssvt.cz', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-03-04 11:23:22', '2025-03-20 20:02:25'),
(2, 1, 'Zikán', 'Čtenář', 'VelmiTajne', 'zikanread@zikan.read', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-03-04 11:35:25', '2025-03-20 20:02:32');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbAccountTypes`
--

CREATE TABLE `tbAccountTypes` (
  `ID` int(11) NOT NULL,
  `TYPE` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbAccountTypes`
--

INSERT INTO `tbAccountTypes` (`ID`, `TYPE`) VALUES
(1, 'Admin'),
(2, 'User');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbCategories`
--

CREATE TABLE `tbCategories` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Description` varchar(1000) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbCategories`
--

INSERT INTO `tbCategories` (`ID`, `NAME`, `Description`) VALUES
(1, 'Logistika', NULL),
(2, 'Ohřívač vody', NULL),
(3, 'Skladování', NULL),
(4, 'Kapaliny', NULL),
(5, 'Plyny', NULL),
(6, 'Automatizace', NULL),
(9, 'Pokus', NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbDeliveryMethods`
--

CREATE TABLE `tbDeliveryMethods` (
  `Id` int(11) NOT NULL,
  `MethodName` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbDeliveryMethods`
--

INSERT INTO `tbDeliveryMethods` (`Id`, `MethodName`) VALUES
(2, 'Kurýr');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbManufacturers`
--

CREATE TABLE `tbManufacturers` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Description` varchar(5000) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbManufacturers`
--

INSERT INTO `tbManufacturers` (`ID`, `NAME`, `Description`) VALUES
(1, 'Interna', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam feugiat, turpis at pulvinar vulputate, erat libero tristique tellus, nec bibendum odio risus sit amet ante. Maecenas ipsum velit, consectetuer eu lobortis ut, dictum at dui. Duis viverra diam non justo. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus. Aliquam erat volutpat. Nullam at arcu a est sollicitudin euismod. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Aliquam ornare wisi eu metus. Etiam ligula pede, sagittis quis, interdum ultricies, scelerisque eu.'),
(2, 'Factor dynamics', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam feugiat, turpis at pulvinar vulputate, erat libero tristique tellus, nec bibendum odio risus sit amet ante. Maecenas ipsum velit, consectetuer eu lobortis ut, dictum at dui. Duis viverra diam non justo. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus. Aliquam erat volutpat. Nullam at arcu a est sollicitudin euismod. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Aliquam ornare wisi eu metus. Etiam ligula pede, sagittis quis, interdum ultricies, scelerisque eu.');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbOrderItem`
--

CREATE TABLE `tbOrderItem` (
  `OrderID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `ProductCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbOrderItem`
--

INSERT INTO `tbOrderItem` (`OrderID`, `ProductID`, `ProductCount`) VALUES
(6, 2, 1),
(7, 7, 5),
(8, 1, 50),
(8, 2, 10),
(8, 5, 1),
(8, 7, 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbOrders`
--

CREATE TABLE `tbOrders` (
  `ID` int(11) NOT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `TotalPrice` decimal(10,2) NOT NULL,
  `OrderDate` datetime NOT NULL,
  `NAME` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Surname` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Adress` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `Mail` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `IsDelivered` tinyint(1) NOT NULL,
  `DeliveryDate` datetime DEFAULT NULL,
  `OrderState` int(11) NOT NULL,
  `PaymentMethod` int(11) NOT NULL,
  `DeliveryMethod` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbOrders`
--

INSERT INTO `tbOrders` (`ID`, `AccountID`, `TotalPrice`, `OrderDate`, `NAME`, `Surname`, `Adress`, `Mail`, `IsDelivered`, `DeliveryDate`, `OrderState`, `PaymentMethod`, `DeliveryMethod`) VALUES
(6, 2, 0.00, '2025-03-20 10:32:12', 'Zikán', 'Čtenář', 'VelmiTajne', 'zikanread@zikan.read', 0, NULL, 2, 1, 2),
(7, 2, 0.00, '2025-03-20 10:41:41', 'Zikán', 'Čtenář', 'VelmiTajne', 'zikanread@zikan.read', 0, NULL, 1, 1, 2),
(8, 2, 169500.00, '2025-03-20 10:57:47', 'Zikán', 'Čtenář', 'VelmiTajne', 'zikanread@zikan.read', 0, NULL, 1, 1, 2);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbOrderStates`
--

CREATE TABLE `tbOrderStates` (
  `ID` int(11) NOT NULL,
  `StateType` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbOrderStates`
--

INSERT INTO `tbOrderStates` (`ID`, `StateType`) VALUES
(1, 'Nová'),
(2, 'Vyřízená');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbPaymentMethod`
--

CREATE TABLE `tbPaymentMethod` (
  `Id` int(11) NOT NULL,
  `MethodName` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbPaymentMethod`
--

INSERT INTO `tbPaymentMethod` (`Id`, `MethodName`) VALUES
(1, 'Kartou');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbProductCategory`
--

CREATE TABLE `tbProductCategory` (
  `ProductID` int(11) NOT NULL,
  `CategoryID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbProductCategory`
--

INSERT INTO `tbProductCategory` (`ProductID`, `CategoryID`) VALUES
(1, 1),
(1, 4),
(1, 5),
(2, 1),
(2, 4),
(2, 5),
(3, 1),
(3, 4),
(3, 5),
(4, 1),
(4, 4),
(4, 5),
(5, 2),
(5, 4),
(5, 5),
(6, 3),
(6, 4),
(6, 5),
(7, 1),
(7, 6),
(13, 6),
(27, 9);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbProducts`
--

CREATE TABLE `tbProducts` (
  `ID` int(11) NOT NULL,
  `NAME` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Description` varchar(5000) COLLATE utf8_czech_ci DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL,
  `Discount` decimal(10,2) DEFAULT NULL,
  `AvailableCount` int(11) DEFAULT NULL,
  `ManufacturerID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbProducts`
--

INSERT INTO `tbProducts` (`ID`, `NAME`, `Description`, `Price`, `Discount`, `AvailableCount`, `ManufacturerID`) VALUES
(1, 'Univerzální přímá trubka', 'Univerzální trubka vhodná pro jakékoliv použití.', 500.00, NULL, 100, 1),
(2, 'Univerzální zahnutá trubka', 'Univerzální zahnutá trubka vhodná pro jakékoliv použití.', 450.00, NULL, 50, 1),
(3, 'Univerzální trubka tvar \"T\"', 'Univerzální trubka vhodná pro jakékoliv použití. Tvarovaná do \"T\" a je tedy možno propojit tři trubky.', 600.00, 200.00, 75, 1),
(4, 'Univerzální trubka tvar \"X\"', 'Univerzální trubka vhodná pro jakékoliv použití. Tvarovaná do \"X\" a je tedy možno propojit až čtyři trubky.', 750.00, NULL, NULL, 1),
(5, 'Bojler', 'Zásobníkový ohřívač vody. Má podobu tlakové nádoby uložené naležato (horizontálně). Objem nádoby 150L.', 15000.00, NULL, 5, 1),
(6, 'Univerzální nádrž', 'Tepelně izolovaná skladovací nádrž. Vhodná pro všechny kapaliny i plyny. Objem 1000L.', 10000.00, 2500.00, NULL, 1),
(7, 'Mechanická paže', 'Mechanická paže vhodná pro automatizaci. Maximalní nosnost paže je 250kg. Pracuje s radiány.', 125000.00, NULL, 5, 2),
(13, 'Montovna', NULL, 350000.00, NULL, NULL, 2),
(27, 'Test', NULL, 1.00, NULL, NULL, 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbReviews`
--

CREATE TABLE `tbReviews` (
  `ID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Rating` smallint(6) NOT NULL,
  `Description` varchar(500) COLLATE utf8_czech_ci DEFAULT NULL,
  `AccountID` int(11) DEFAULT NULL,
  `Redacted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbReviews`
--

INSERT INTO `tbReviews` (`ID`, `ProductID`, `Rating`, `Description`, `AccountID`, `Redacted`) VALUES
(1, 1, 10, 'Je to trubka, co k tomu říct. Dělá co by trubka měla...', NULL, 0),
(2, 7, 0, 'ONO TO PRACUJE V RADIANECH!!! JÁ TAM NASTAVIL HODNOTY V ÚHLECH A ROZMLATÍLO MI TO VŠECHNY VĚCI OKOLO!! KRÁM NEKUPOVAT!!!', NULL, 0),
(3, 1, 8, NULL, NULL, 0),
(4, 1, 0, NULL, NULL, 0),
(5, 1, 3, NULL, NULL, 0),
(6, 1, 8, 'Má to pěkný design.', NULL, 0),
(7, 4, 10, 'Je na tom fakt dobrý, to že opravdu lze připojit až 4 trubky!', 2, 0),
(8, 2, 10, 'Skvělý produkt, koupil jsem si jich víc a udělal tunel pro kočky.', NULL, 0),
(9, 13, 9, 'SUPER! ', NULL, 0),
(10, 2, 5, 'Dobře se na tom ukazuje tok DTO přes internet na backend a pak do databáze\r\n', 2, 0),
(11, 7, 5, 'V průběhu práce se zasekla, nemohl jsem ji dostat dolu musel jsem do nemocnice', NULL, 0),
(12, 6, 10, 'Používám doma na kafe.... mohla by být větší vydrží mi pouze 3 hodiny, než ji musím doplnit. Jinak doporučuju :D', NULL, 0);

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `tbAccounts`
--
ALTER TABLE `tbAccounts`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_Account_AccountType` (`AccountType`);

--
-- Klíče pro tabulku `tbAccountTypes`
--
ALTER TABLE `tbAccountTypes`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `tbCategories`
--
ALTER TABLE `tbCategories`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `tbDeliveryMethods`
--
ALTER TABLE `tbDeliveryMethods`
  ADD PRIMARY KEY (`Id`);

--
-- Klíče pro tabulku `tbManufacturers`
--
ALTER TABLE `tbManufacturers`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `tbOrderItem`
--
ALTER TABLE `tbOrderItem`
  ADD PRIMARY KEY (`OrderID`,`ProductID`),
  ADD KEY `FK_OrderItem_Product` (`ProductID`);

--
-- Klíče pro tabulku `tbOrders`
--
ALTER TABLE `tbOrders`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ID` (`ID`),
  ADD KEY `FK_Accounts_Order` (`AccountID`),
  ADD KEY `FK_States_Order` (`OrderState`),
  ADD KEY `FK_PaymentMethod` (`PaymentMethod`),
  ADD KEY `FK_DeliveryMethod` (`DeliveryMethod`);

--
-- Klíče pro tabulku `tbOrderStates`
--
ALTER TABLE `tbOrderStates`
  ADD PRIMARY KEY (`ID`);

--
-- Klíče pro tabulku `tbPaymentMethod`
--
ALTER TABLE `tbPaymentMethod`
  ADD PRIMARY KEY (`Id`);

--
-- Klíče pro tabulku `tbProductCategory`
--
ALTER TABLE `tbProductCategory`
  ADD PRIMARY KEY (`ProductID`,`CategoryID`),
  ADD KEY `FK_tbProductCategory_tbCategories` (`CategoryID`);

--
-- Klíče pro tabulku `tbProducts`
--
ALTER TABLE `tbProducts`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_tbProducts_tbManufacturers` (`ManufacturerID`);

--
-- Klíče pro tabulku `tbReviews`
--
ALTER TABLE `tbReviews`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_Reviews_Account` (`AccountID`),
  ADD KEY `FK_Reviews_Product` (`ProductID`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `tbAccounts`
--
ALTER TABLE `tbAccounts`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pro tabulku `tbAccountTypes`
--
ALTER TABLE `tbAccountTypes`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `tbCategories`
--
ALTER TABLE `tbCategories`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pro tabulku `tbDeliveryMethods`
--
ALTER TABLE `tbDeliveryMethods`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pro tabulku `tbManufacturers`
--
ALTER TABLE `tbManufacturers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pro tabulku `tbOrders`
--
ALTER TABLE `tbOrders`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT pro tabulku `tbOrderStates`
--
ALTER TABLE `tbOrderStates`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pro tabulku `tbPaymentMethod`
--
ALTER TABLE `tbPaymentMethod`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pro tabulku `tbProducts`
--
ALTER TABLE `tbProducts`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT pro tabulku `tbReviews`
--
ALTER TABLE `tbReviews`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `tbAccounts`
--
ALTER TABLE `tbAccounts`
  ADD CONSTRAINT `FK_Account_AccountType` FOREIGN KEY (`AccountType`) REFERENCES `tbAccountTypes` (`ID`);

--
-- Omezení pro tabulku `tbOrderItem`
--
ALTER TABLE `tbOrderItem`
  ADD CONSTRAINT `FK_OrderItem_Order` FOREIGN KEY (`OrderID`) REFERENCES `tbOrders` (`ID`),
  ADD CONSTRAINT `FK_OrderItem_Product` FOREIGN KEY (`ProductID`) REFERENCES `tbProducts` (`ID`);

--
-- Omezení pro tabulku `tbOrders`
--
ALTER TABLE `tbOrders`
  ADD CONSTRAINT `FK_Accounts_Order` FOREIGN KEY (`AccountID`) REFERENCES `tbAccounts` (`ID`),
  ADD CONSTRAINT `FK_States_Order` FOREIGN KEY (`OrderState`) REFERENCES `tbOrderStates` (`ID`),
  ADD CONSTRAINT `tbOrders_ibfk_1` FOREIGN KEY (`PaymentMethod`) REFERENCES `tbPaymentMethod` (`Id`),
  ADD CONSTRAINT `tbOrders_ibfk_2` FOREIGN KEY (`DeliveryMethod`) REFERENCES `tbDeliveryMethods` (`Id`);

--
-- Omezení pro tabulku `tbProductCategory`
--
ALTER TABLE `tbProductCategory`
  ADD CONSTRAINT `FK_tbProductCategory_tbCategories` FOREIGN KEY (`CategoryID`) REFERENCES `tbCategories` (`ID`),
  ADD CONSTRAINT `FK_tbProductCategory_tbProducts` FOREIGN KEY (`ProductID`) REFERENCES `tbProducts` (`ID`);

--
-- Omezení pro tabulku `tbProducts`
--
ALTER TABLE `tbProducts`
  ADD CONSTRAINT `FK_tbProducts_tbManufacturers` FOREIGN KEY (`ManufacturerID`) REFERENCES `tbManufacturers` (`ID`);

--
-- Omezení pro tabulku `tbReviews`
--
ALTER TABLE `tbReviews`
  ADD CONSTRAINT `FK_Reviews_Account` FOREIGN KEY (`AccountID`) REFERENCES `tbAccounts` (`ID`),
  ADD CONSTRAINT `FK_Reviews_Product` FOREIGN KEY (`ProductID`) REFERENCES `tbProducts` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
