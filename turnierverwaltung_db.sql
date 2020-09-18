-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 18. Sep 2020 um 08:59
-- Server-Version: 10.1.37-MariaDB
-- PHP-Version: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `turnierverwaltung_db`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `fussballspieler`
--

CREATE TABLE `fussballspieler` (
  `Fussballspieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT '0',
  `Tore` int(5) NOT NULL DEFAULT '0',
  `Position` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `fussballspieler`
--

INSERT INTO `fussballspieler` (`Fussballspieler_ID`, `Person_ID`, `Spiele`, `Tore`, `Position`) VALUES
(1, 1, 50, 60, 'Strümer');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `handballspieler`
--

CREATE TABLE `handballspieler` (
  `Handballspieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT '0',
  `Tore` int(5) DEFAULT '0',
  `Position` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `Mannschaft_ID` int(5) NOT NULL,
  `Name` varchar(50) COLLATE latin1_german2_ci NOT NULL,
  `Sport_Art` varchar(50) COLLATE latin1_german2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft_mitglieder`
--

CREATE TABLE `mannschaft_mitglieder` (
  `Mannschaft_Mitglieder_ID` int(5) NOT NULL,
  `Mannschaft_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mitarbeiter`
--

CREATE TABLE `mitarbeiter` (
  `Mitarbeiter_ID` int(11) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Aufgabe` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL,
  `Sport_Art` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

CREATE TABLE `person` (
  `Person_ID` int(5) NOT NULL,
  `Art` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL,
  `Art_ID` int(5) NOT NULL,
  `Vorname` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL,
  `Nachname` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL,
  `Geburtsdatum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`Person_ID`, `Art`, `Art_ID`, `Vorname`, `Nachname`, `Geburtsdatum`) VALUES
(1, 'FussballSpieler', 1, 'f', 'f', '2020-09-17'),
(2, '', 0, 'h', 'h', '2020-09-17');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `physiotherapeut`
--

CREATE TABLE `physiotherapeut` (
  `Physiotherapeut_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Jahre` int(5) NOT NULL DEFAULT '0',
  `Sport_Art` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spieler`
--

CREATE TABLE `spieler` (
  `Spieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT '0',
  `Gewonnene_Spiele` int(5) NOT NULL DEFAULT '0',
  `Sport_Art` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `sportart`
--

CREATE TABLE `sportart` (
  `Sport_Art_ID` int(5) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `sportart`
--

INSERT INTO `sportart` (`Sport_Art_ID`, `name`) VALUES
(1, 'Fussball'),
(2, 'Handball'),
(3, 'Tennis');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tennisspieler`
--

CREATE TABLE `tennisspieler` (
  `Tennisspieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT '0',
  `Gewonnene_Spiele` int(5) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `trainer`
--

CREATE TABLE `trainer` (
  `Trainer_ID` int(11) NOT NULL,
  `Person_ID` int(5) NOT NULL DEFAULT '0',
  `Vereine` int(5) NOT NULL DEFAULT '0',
  `Sport_Art` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `users`
--

CREATE TABLE `users` (
  `ID` int(4) NOT NULL,
  `name` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL,
  `password` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL,
  `rolle` varchar(50) COLLATE utf8mb4_german2_ci NOT NULL,
  `active` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `users`
--

INSERT INTO `users` (`ID`, `name`, `password`, `rolle`, `active`) VALUES
(1, 'admin', '21232f297a57a5a743894a0e4a801fc3', 'admin', 1),
(2, 'user', 'ee11cbb19052e40b07aac0ca060c23ee', 'user', 1);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `fussballspieler`
--
ALTER TABLE `fussballspieler`
  ADD PRIMARY KEY (`Fussballspieler_ID`);

--
-- Indizes für die Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  ADD PRIMARY KEY (`Handballspieler_ID`);

--
-- Indizes für die Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  ADD PRIMARY KEY (`Mannschaft_ID`);

--
-- Indizes für die Tabelle `mannschaft_mitglieder`
--
ALTER TABLE `mannschaft_mitglieder`
  ADD PRIMARY KEY (`Mannschaft_Mitglieder_ID`);

--
-- Indizes für die Tabelle `mitarbeiter`
--
ALTER TABLE `mitarbeiter`
  ADD PRIMARY KEY (`Mitarbeiter_ID`);

--
-- Indizes für die Tabelle `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`Person_ID`),
  ADD KEY `Art_ID` (`Art_ID`);

--
-- Indizes für die Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  ADD PRIMARY KEY (`Physiotherapeut_ID`);

--
-- Indizes für die Tabelle `spieler`
--
ALTER TABLE `spieler`
  ADD PRIMARY KEY (`Spieler_ID`);

--
-- Indizes für die Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  ADD PRIMARY KEY (`Tennisspieler_ID`);

--
-- Indizes für die Tabelle `trainer`
--
ALTER TABLE `trainer`
  ADD PRIMARY KEY (`Trainer_ID`);

--
-- Indizes für die Tabelle `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `fussballspieler`
--
ALTER TABLE `fussballspieler`
  MODIFY `Fussballspieler_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  MODIFY `Handballspieler_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `Mannschaft_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `mannschaft_mitglieder`
--
ALTER TABLE `mannschaft_mitglieder`
  MODIFY `Mannschaft_Mitglieder_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `mitarbeiter`
--
ALTER TABLE `mitarbeiter`
  MODIFY `Mitarbeiter_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `Person_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `Physiotherapeut_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `spieler`
--
ALTER TABLE `spieler`
  MODIFY `Spieler_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  MODIFY `Tennisspieler_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `trainer`
--
ALTER TABLE `trainer`
  MODIFY `Trainer_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
