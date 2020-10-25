-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 25. Okt 2020 um 20:09
-- Server-Version: 10.4.11-MariaDB
-- PHP-Version: 7.2.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `turnierverwaltung_db`
--
CREATE DATABASE IF NOT EXISTS `turnierverwaltung_db` DEFAULT CHARACTER SET latin1 COLLATE latin1_general_cs;
USE `turnierverwaltung_db`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `fussballspieler`
--

CREATE TABLE `fussballspieler` (
  `Fussballspieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT 0,
  `Tore` int(5) NOT NULL DEFAULT 0,
  `Position` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `fussballspieler`
--

INSERT INTO `fussballspieler` (`Fussballspieler_ID`, `Person_ID`, `Spiele`, `Tore`, `Position`) VALUES
(1, 1, 4, 0, 'Tor'),
(2, 2, 5, 9, 'Tor'),
(3, 3, 12, 11, 'Abwehr'),
(4, 4, 7, 15, 'Abwehr'),
(5, 5, 20, 18, 'Abwehr'),
(6, 6, 29, 17, 'Abwehr'),
(7, 7, 28, 18, 'Abwehr'),
(8, 8, 46, 31, 'Abwehr'),
(9, 9, 56, 18, 'Mittelfeld'),
(10, 10, 17, 8, 'Mittelfeld'),
(11, 11, 46, 18, 'Mittelfeld'),
(12, 12, 71, 27, 'Mittelfeld'),
(13, 13, 15, 8, 'Mittelfeld'),
(14, 14, 37, 15, 'Mittelfeld'),
(15, 15, 26, 8, 'Mittelfeld'),
(16, 16, 52, 7, 'Mittelfeld'),
(17, 17, 21, 5, 'Mittelfeld'),
(18, 18, 16, 14, 'Mittelfeld'),
(19, 19, 18, 10, 'Sturm'),
(20, 20, 12, 2, 'Sturm'),
(21, 21, 21, 31, 'Sturm');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `handballspieler`
--

CREATE TABLE `handballspieler` (
  `Handballspieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT 0,
  `Tore` int(5) DEFAULT 0,
  `Position` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `handballspieler`
--

INSERT INTO `handballspieler` (`Handballspieler_ID`, `Person_ID`, `Spiele`, `Tore`, `Position`) VALUES
(1, 22, 12, 7, 'Sturm'),
(2, 23, 16, 8, 'Abwehr');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `Mannschaft_ID` int(5) NOT NULL,
  `Name` varchar(50) COLLATE latin1_german2_ci NOT NULL,
  `Sport_Art` varchar(50) COLLATE latin1_german2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

--
-- Daten für Tabelle `mannschaft`
--

INSERT INTO `mannschaft` (`Mannschaft_ID`, `Name`, `Sport_Art`) VALUES
(1, 'FC Augsburg', 'Fussball'),
(2, 'FC Union Berlin', 'Fussball'),
(3, 'Hertha BSC', 'Fussball'),
(4, 'Arminia Bielefeld', 'Fussball'),
(5, 'Werder Bremen', 'Fussball'),
(6, 'Borussia Dortmund', 'Fussball'),
(7, 'Eintracht Frankfurt', 'Fussball'),
(8, 'SC Freiburg', 'Fussball'),
(9, 'TSG Hoffenheim', 'Fussball'),
(10, '1. FC Köln', 'Fussball'),
(11, 'RB Leipzig', 'Fussball'),
(12, 'Bayer 04 Leverkusen', 'Fussball'),
(13, '1. FSV Mainz 05', 'Fussball'),
(14, 'Bor. Mönchengladbach', 'Fussball'),
(15, 'Bayern München', 'Fussball'),
(16, 'FC Schalke 04', 'Fussball'),
(17, 'VfB Stuttgart', 'Fussball'),
(18, 'VfL Wolfsburg', 'Fussball'),
(19, 'Fortuna Düsseldorf', 'Fussball'),
(20, 'Hannover 96', 'Fussball');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft_mitglieder`
--

CREATE TABLE `mannschaft_mitglieder` (
  `Mannschaft_Mitglieder_ID` int(5) NOT NULL,
  `Mannschaft_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

--
-- Daten für Tabelle `mannschaft_mitglieder`
--

INSERT INTO `mannschaft_mitglieder` (`Mannschaft_Mitglieder_ID`, `Mannschaft_ID`, `Person_ID`) VALUES
(6, 3, 25),
(7, 3, 26),
(8, 3, 3),
(9, 4, 8),
(10, 4, 25),
(11, 4, 2),
(12, 4, 1),
(14, 6, 6),
(15, 6, 11),
(16, 7, 27),
(17, 7, 17),
(18, 7, 15),
(19, 7, 4),
(20, 7, 2),
(21, 7, 1),
(22, 7, 6),
(23, 8, 3),
(24, 8, 16),
(25, 8, 17),
(26, 8, 27),
(27, 8, 26),
(31, 12, 1),
(32, 12, 3),
(33, 12, 5),
(34, 12, 6),
(35, 13, 2),
(36, 13, 1),
(37, 13, 4),
(38, 13, 3),
(39, 14, 4),
(40, 14, 5),
(41, 14, 6),
(42, 14, 3),
(43, 14, 7),
(44, 14, 8),
(45, 15, 27),
(46, 15, 4),
(47, 15, 25),
(48, 15, 5),
(49, 15, 1),
(50, 15, 3),
(51, 16, 3),
(52, 16, 25),
(53, 16, 26),
(54, 16, 19),
(55, 16, 20),
(56, 16, 16),
(57, 17, 19),
(58, 17, 15),
(59, 17, 21),
(60, 17, 20),
(61, 17, 27),
(62, 18, 18),
(63, 18, 20),
(64, 18, 21),
(65, 18, 25),
(66, 18, 1),
(67, 18, 2),
(68, 19, 19),
(69, 19, 1),
(70, 19, 20),
(71, 19, 4),
(72, 19, 26),
(73, 19, 27),
(74, 20, 19),
(75, 20, 14),
(76, 20, 21),
(77, 20, 2),
(78, 20, 3),
(79, 20, 1),
(80, 20, 5),
(81, 20, 6),
(82, 9, 3),
(83, 9, 5),
(84, 9, 4),
(85, 9, 2),
(86, 10, 20),
(87, 10, 1),
(88, 10, 21),
(89, 10, 19),
(90, 10, 2),
(91, 11, 21),
(92, 11, 5),
(93, 11, 20),
(94, 11, 3),
(95, 11, 1),
(96, 11, 4),
(97, 5, 21),
(98, 5, 5),
(99, 5, 2),
(100, 5, 3),
(101, 5, 4),
(102, 5, 6),
(103, 1, 1),
(104, 1, 2),
(105, 1, 4),
(106, 1, 3),
(107, 1, 6),
(108, 1, 5),
(109, 1, 8),
(110, 1, 10),
(111, 1, 9),
(112, 2, 11),
(113, 2, 27),
(114, 2, 3),
(115, 2, 2),
(116, 2, 20),
(117, 2, 13),
(118, 2, 12);

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

--
-- Daten für Tabelle `mitarbeiter`
--

INSERT INTO `mitarbeiter` (`Mitarbeiter_ID`, `Person_ID`, `Aufgabe`, `Sport_Art`) VALUES
(1, 27, 'Fussbalssammler', 'Fussball');

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
(1, 'FussballSpieler', 1, 'Rafal', 'Gikiewicz', '2019-10-17'),
(2, 'FussballSpieler', 2, 'Leneis', 'Leneis', '2020-10-15'),
(3, 'FussballSpieler', 3, 'Framberger', 'Raphael', '2020-09-25'),
(4, 'FussballSpieler', 4, 'Gouweleeuw', 'Jeffrey', '2019-10-25'),
(5, 'FussballSpieler', 5, 'Gumny', 'Robert', '2020-10-25'),
(6, 'FussballSpieler', 6, 'Oxford', 'Reece', '2019-11-25'),
(7, 'FussballSpieler', 7, 'Suchy', 'Marek', '2020-10-25'),
(8, 'FussballSpieler', 8, 'Uduokhai', 'Felix', '2020-10-25'),
(9, 'FussballSpieler', 9, 'Caligiuri', 'Daniel', '2020-10-25'),
(10, 'FussballSpieler', 10, 'Götze', 'Felix', '2020-10-25'),
(11, 'FussballSpieler', 11, 'Gruezo', 'Carlos', '2020-10-25'),
(12, 'FussballSpieler', 12, 'Hahn', 'André', '2020-10-25'),
(13, 'FussballSpieler', 13, 'Jensen', 'Fredrik', '2020-10-25'),
(14, 'FussballSpieler', 14, 'Khedira', 'Rani', '2020-10-25'),
(15, 'FussballSpieler', 15, 'Moravek', 'Jan', '2020-10-25'),
(16, 'FussballSpieler', 16, 'Richter', 'Marco', '2020-10-25'),
(17, 'FussballSpieler', 17, 'Strobl', 'Tobias', '2020-10-25'),
(18, 'FussballSpieler', 18, 'Vargas', 'Ruben', '2020-10-25'),
(19, 'FussballSpieler', 19, 'Finnbogason', 'Alfred', '2020-10-25'),
(20, 'FussballSpieler', 20, 'Gregoritsch', 'Michael', '2020-10-25'),
(21, 'FussballSpieler', 21, 'Niederlechner', 'Florian', '2020-10-25'),
(22, 'HandballSpieler', 1, 'Linner', 'Oscar', '2020-10-25'),
(23, 'HandballSpieler', 2, 'Ortega', 'Stefan', '2020-10-25'),
(24, 'TennisSpieler', 1, 'Rehnen', 'Nikolai', '2020-10-25'),
(25, 'Physiotherapeut', 1, 'Behrendt', 'Brian', '2020-10-25'),
(26, 'Trainer', 1, 'Brunner', 'Cedric', '2020-10-25'),
(27, 'Mitarbeiter', 1, 'Laursen', 'Jacob', '2020-10-25');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `physiotherapeut`
--

CREATE TABLE `physiotherapeut` (
  `Physiotherapeut_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Jahre` int(5) NOT NULL DEFAULT 0,
  `Sport_Art` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `physiotherapeut`
--

INSERT INTO `physiotherapeut` (`Physiotherapeut_ID`, `Person_ID`, `Jahre`, `Sport_Art`) VALUES
(1, 25, 22, 'Fussball');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spiel`
--

CREATE TABLE `spiel` (
  `Spiel_ID` int(5) NOT NULL,
  `Turnier_ID` int(5) NOT NULL,
  `Mannschaft_ID` int(5) NOT NULL,
  `Punkte` int(5) NOT NULL,
  `Gegen_Mannschaft_ID` int(5) NOT NULL,
  `Gegen_Punkte` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

--
-- Daten für Tabelle `spiel`
--

INSERT INTO `spiel` (`Spiel_ID`, `Turnier_ID`, `Mannschaft_ID`, `Punkte`, `Gegen_Mannschaft_ID`, `Gegen_Punkte`) VALUES
(1, 1, 1, 3, 2, 1),
(2, 1, 1, 6, 15, 8),
(3, 1, 9, 5, 2, 6),
(4, 1, 17, 8, 1, 7),
(5, 1, 11, 0, 15, 0),
(6, 1, 17, 4, 15, 6),
(7, 1, 1, 3, 11, 2),
(8, 1, 11, 3, 1, 4),
(9, 1, 9, 4, 11, 2),
(10, 1, 11, 2, 2, 4),
(11, 2, 16, 1, 1, 0),
(12, 2, 5, 3, 11, 1),
(13, 2, 5, 1, 15, 2),
(14, 2, 16, 4, 20, 1),
(15, 2, 14, 5, 13, 4),
(16, 2, 13, 3, 5, 6),
(17, 2, 15, 5, 16, 4),
(18, 2, 20, 2, 1, 5),
(19, 2, 5, 5, 16, 6),
(20, 2, 12, 5, 20, 4),
(21, 2, 12, 1, 13, 1),
(22, 2, 13, 0, 11, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spieler`
--

CREATE TABLE `spieler` (
  `Spieler_ID` int(5) NOT NULL,
  `Person_ID` int(5) NOT NULL,
  `Spiele` int(5) NOT NULL DEFAULT 0,
  `Gewonnene_Spiele` int(5) NOT NULL DEFAULT 0,
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
  `Spiele` int(5) NOT NULL DEFAULT 0,
  `Tore` int(5) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `tennisspieler`
--

INSERT INTO `tennisspieler` (`Tennisspieler_ID`, `Person_ID`, `Spiele`, `Tore`) VALUES
(1, 24, 25, 51);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `trainer`
--

CREATE TABLE `trainer` (
  `Trainer_ID` int(11) NOT NULL,
  `Person_ID` int(5) NOT NULL DEFAULT 0,
  `Vereine` int(5) NOT NULL DEFAULT 0,
  `Sport_Art` varchar(50) COLLATE utf8mb4_german2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_german2_ci;

--
-- Daten für Tabelle `trainer`
--

INSERT INTO `trainer` (`Trainer_ID`, `Person_ID`, `Vereine`, `Sport_Art`) VALUES
(1, 26, 12, 'Fussball');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier`
--

CREATE TABLE `turnier` (
  `Turnier_ID` int(5) NOT NULL,
  `Verein_Name` varchar(250) COLLATE latin1_german2_ci NOT NULL,
  `Adresse` varchar(250) COLLATE latin1_german2_ci DEFAULT NULL,
  `Datum_von` date DEFAULT NULL,
  `Datum_bis` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

--
-- Daten für Tabelle `turnier`
--

INSERT INTO `turnier` (`Turnier_ID`, `Verein_Name`, `Adresse`, `Datum_von`, `Datum_bis`) VALUES
(1, 'Bundesliga 2020/21', 'Berlin', '2020-10-25', '2020-11-04'),
(2, 'Bundesliga 2019/20', 'Düsseldorf', '2020-10-25', '2020-11-04');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier_mannschaft`
--

CREATE TABLE `turnier_mannschaft` (
  `Turnier_Mannschaft_ID` int(5) NOT NULL,
  `Turnier_ID` int(5) NOT NULL,
  `Mannschaft_ID` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_german2_ci;

--
-- Daten für Tabelle `turnier_mannschaft`
--

INSERT INTO `turnier_mannschaft` (`Turnier_Mannschaft_ID`, `Turnier_ID`, `Mannschaft_ID`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 9),
(4, 1, 11),
(5, 1, 15),
(6, 1, 17),
(7, 2, 1),
(8, 2, 5),
(9, 2, 11),
(10, 2, 12),
(11, 2, 13),
(12, 2, 14),
(13, 2, 15),
(14, 2, 16),
(15, 2, 20);

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
-- Indizes für die Tabelle `spiel`
--
ALTER TABLE `spiel`
  ADD PRIMARY KEY (`Spiel_ID`),
  ADD KEY `Turnier_ID` (`Turnier_ID`),
  ADD KEY `Punkte1` (`Punkte`);

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
-- Indizes für die Tabelle `turnier`
--
ALTER TABLE `turnier`
  ADD PRIMARY KEY (`Turnier_ID`);

--
-- Indizes für die Tabelle `turnier_mannschaft`
--
ALTER TABLE `turnier_mannschaft`
  ADD PRIMARY KEY (`Turnier_Mannschaft_ID`);

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
  MODIFY `Fussballspieler_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT für Tabelle `handballspieler`
--
ALTER TABLE `handballspieler`
  MODIFY `Handballspieler_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `Mannschaft_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT für Tabelle `mannschaft_mitglieder`
--
ALTER TABLE `mannschaft_mitglieder`
  MODIFY `Mannschaft_Mitglieder_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=119;

--
-- AUTO_INCREMENT für Tabelle `mitarbeiter`
--
ALTER TABLE `mitarbeiter`
  MODIFY `Mitarbeiter_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `Person_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT für Tabelle `physiotherapeut`
--
ALTER TABLE `physiotherapeut`
  MODIFY `Physiotherapeut_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `spiel`
--
ALTER TABLE `spiel`
  MODIFY `Spiel_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT für Tabelle `spieler`
--
ALTER TABLE `spieler`
  MODIFY `Spieler_ID` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT für Tabelle `tennisspieler`
--
ALTER TABLE `tennisspieler`
  MODIFY `Tennisspieler_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `trainer`
--
ALTER TABLE `trainer`
  MODIFY `Trainer_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `turnier`
--
ALTER TABLE `turnier`
  MODIFY `Turnier_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT für Tabelle `turnier_mannschaft`
--
ALTER TABLE `turnier_mannschaft`
  MODIFY `Turnier_Mannschaft_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT für Tabelle `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
