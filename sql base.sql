-- --------------------------------------------------------
-- Хост:                         192.168.0.94
-- Версия сервера:               8.0.20 - MySQL Community Server - GPL
-- Операционная система:         Linux
-- HeidiSQL Версия:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных is-32-tkachenm
DROP DATABASE IF EXISTS `is-32-tkachenm`;
CREATE DATABASE IF NOT EXISTS `is-32-tkachenm` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `is-32-tkachenm`;

-- Дамп структуры для таблица is-32-tkachenm.Adress
DROP TABLE IF EXISTS `Adress`;
CREATE TABLE IF NOT EXISTS `Adress` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы is-32-tkachenm.Adress: ~6 rows (приблизительно)
DELETE FROM `Adress`;
/*!40000 ALTER TABLE `Adress` DISABLE KEYS */;
INSERT INTO `Adress` (`ID`, `Name`) VALUES
	(1, 'Ул. Гачийная д.19 кв.69'),
	(2, 'Ул. Зеленая д.7 кв.44'),
	(3, 'Ул. Им. А.Пушкина д.23 кв'),
	(4, 'Ул. Им. Б.Ручьева д.5 кв.'),
	(5, 'Ул. Ффная д.322 кв.15'),
	(6, 'gfg');
/*!40000 ALTER TABLE `Adress` ENABLE KEYS */;

-- Дамп структуры для таблица is-32-tkachenm.Diagnosis
DROP TABLE IF EXISTS `Diagnosis`;
CREATE TABLE IF NOT EXISTS `Diagnosis` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы is-32-tkachenm.Diagnosis: ~5 rows (приблизительно)
DELETE FROM `Diagnosis`;
/*!40000 ALTER TABLE `Diagnosis` DISABLE KEYS */;
INSERT INTO `Diagnosis` (`ID`, `Name`) VALUES
	(1, 'Восполение слизистой оболочки'),
	(2, 'Восполене век'),
	(3, 'Катаракта'),
	(4, 'Глаукома'),
	(5, 'Дегенерация макулы');
/*!40000 ALTER TABLE `Diagnosis` ENABLE KEYS */;

-- Дамп структуры для таблица is-32-tkachenm.Doctor
DROP TABLE IF EXISTS `Doctor`;
CREATE TABLE IF NOT EXISTS `Doctor` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы is-32-tkachenm.Doctor: ~7 rows (приблизительно)
DELETE FROM `Doctor`;
/*!40000 ALTER TABLE `Doctor` DISABLE KEYS */;
INSERT INTO `Doctor` (`ID`, `Name`) VALUES
	(1, 'Архипов Родион Богданович'),
	(2, 'Белов Вальтер Миронович'),
	(3, 'Большаков Савелий Игоревич'),
	(4, 'Герасимов Иннокентий Алексеевич'),
	(5, 'Зуев Вячеслав Григорьевич'),
	(6, 'Коннонов Захар Проклович'),
	(7, 'Красильников Марк Рудольфович');
/*!40000 ALTER TABLE `Doctor` ENABLE KEYS */;

-- Дамп структуры для таблица is-32-tkachenm.Journal
DROP TABLE IF EXISTS `Journal`;
CREATE TABLE IF NOT EXISTS `Journal` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `DiagnosisID` int NOT NULL,
  `PatientID` int NOT NULL,
  `AdressID` int NOT NULL,
  `DoctorID` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `DiagnosisID` (`DiagnosisID`),
  KEY `PatientID` (`PatientID`),
  KEY `AdressID` (`AdressID`),
  KEY `DoctorID` (`DoctorID`),
  CONSTRAINT `AdressID` FOREIGN KEY (`AdressID`) REFERENCES `Adress` (`ID`),
  CONSTRAINT `DiagnosisID` FOREIGN KEY (`DiagnosisID`) REFERENCES `Diagnosis` (`ID`),
  CONSTRAINT `DoctorID` FOREIGN KEY (`DoctorID`) REFERENCES `Doctor` (`ID`),
  CONSTRAINT `PatientID` FOREIGN KEY (`PatientID`) REFERENCES `Patient` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы is-32-tkachenm.Journal: ~2 rows (приблизительно)
DELETE FROM `Journal`;
/*!40000 ALTER TABLE `Journal` DISABLE KEYS */;
INSERT INTO `Journal` (`ID`, `Date`, `DiagnosisID`, `PatientID`, `AdressID`, `DoctorID`) VALUES
	(1, '2020-11-23', 4, 3, 1, 6),
	(2, '0001-01-01', 2, 4, 2, 7);
/*!40000 ALTER TABLE `Journal` ENABLE KEYS */;

-- Дамп структуры для таблица is-32-tkachenm.Patient
DROP TABLE IF EXISTS `Patient`;
CREATE TABLE IF NOT EXISTS `Patient` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы is-32-tkachenm.Patient: ~6 rows (приблизительно)
DELETE FROM `Patient`;
/*!40000 ALTER TABLE `Patient` DISABLE KEYS */;
INSERT INTO `Patient` (`ID`, `Name`) VALUES
	(1, 'Волокитин Данил Данилович'),
	(2, 'Казакова Зара Эльдаровна'),
	(3, 'Котов Филипп Ильич'),
	(4, 'Моисеева Анфиса Игнатьевн'),
	(5, 'Плчв Илья Алексеевич'),
	(6, 'Кржк Егр Влдмрч');
/*!40000 ALTER TABLE `Patient` ENABLE KEYS */;

-- Дамп структуры для таблица is-32-tkachenm.users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Login` varchar(50) DEFAULT '',
  `Password` varchar(50) DEFAULT '',
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Login` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Дамп данных таблицы is-32-tkachenm.users: ~2 rows (приблизительно)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`ID`, `Login`, `Password`, `Name`) VALUES
	(1, 'Admin', 'qwerty', 'Администратор'),
	(2, 'Regr', 'qwerty', 'Работник регистратуры');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
