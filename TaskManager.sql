-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: taskmanager
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `Id` int NOT NULL,
  `Surname` varchar(45) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Patronomic` varchar(45) NOT NULL,
  `Login` varchar(15) NOT NULL,
  `Password` varchar(15) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Симонов','Остап','Вадимович','123','1'),(2,'Попов','Емельян','Иринеевич','123','2'),(3,'Доронин','Глеб','Фролович','123','3');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `Id` int NOT NULL,
  `Full_title` text NOT NULL,
  `Short_title` varchar(5) DEFAULT NULL,
  `Icon` text,
  `Created_time` datetime NOT NULL,
  `Deleted_time` datetime DEFAULT NULL,
  `Start_scheduled_date` datetime DEFAULT NULL,
  `Finish_scheduled_date` datetime DEFAULT NULL,
  `Description` text,
  `Creator_employee_id` int NOT NULL,
  `Responsible_employee_id` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Executive_employee_idx` (`Responsible_employee_id`),
  KEY `Creator_employee_idx` (`Creator_employee_id`),
  CONSTRAINT `Creator_employee` FOREIGN KEY (`Id`) REFERENCES `employee` (`Id`),
  CONSTRAINT `Responsible_employee` FOREIGN KEY (`Responsible_employee_id`) REFERENCES `employee` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES (1,'TaskManager','TM','C:\\Users\\10a\\Desktop\\TaskManager-main\\Project\\bin\\Debug\\net7.0-windows../../../../Assets/Images/TaskManager.png','2028-06-20 23:00:00',NULL,NULL,NULL,NULL,1,NULL),(2,'CraftEditor','CE','C:\\Users\\10a\\Desktop\\TaskManager-main\\Project\\bin\\Debug\\net7.0-windows../../../../Assets/Images/CraftEditor.png','2028-06-20 23:00:00',NULL,NULL,NULL,NULL,2,NULL),(3,'ScreenshotToMassanger','SC','C:\\Users\\10a\\Desktop\\TaskManager-main\\Project\\bin\\Debug\\net7.0-windows../../../../Assets/Images/ScreenshotToMassanger.png','2028-06-20 23:00:00',NULL,NULL,NULL,NULL,3,NULL);
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task`
--

DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task` (
  `Id` int NOT NULL,
  `Project_id` int NOT NULL,
  `Full_title` text NOT NULL,
  `Short_title` varchar(15) DEFAULT NULL,
  `Description` text,
  `Executive_employee_id` int DEFAULT NULL,
  `Status_id` int NOT NULL DEFAULT '1',
  `Created_time` datetime NOT NULL,
  `Updated_time` datetime DEFAULT NULL,
  `Deleted_time` datetime DEFAULT NULL,
  `Deadliine` datetime DEFAULT NULL,
  `Start_actual_time` datetime DEFAULT NULL,
  `Finish_actual_time` datetime DEFAULT NULL,
  `Previous_task_id` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Status_idx` (`Status_id`),
  KEY `Task_idx` (`Previous_task_id`),
  KEY `Employee_idx` (`Executive_employee_id`),
  CONSTRAINT `Employee` FOREIGN KEY (`Executive_employee_id`) REFERENCES `employee` (`Id`),
  CONSTRAINT `Project` FOREIGN KEY (`Id`) REFERENCES `project` (`Id`),
  CONSTRAINT `Status` FOREIGN KEY (`Status_id`) REFERENCES `task_status` (`Id`),
  CONSTRAINT `Task` FOREIGN KEY (`Previous_task_id`) REFERENCES `task` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task`
--

LOCK TABLES `task` WRITE;
/*!40000 ALTER TABLE `task` DISABLE KEYS */;
INSERT INTO `task` VALUES (1,1,'Обновление UI','ОU','Обновление UI приложения',1,1,'2023-06-29 15:51:50','2023-06-29 15:51:50',NULL,'2020-01-31 00:00:00','2020-01-03 00:00:00',NULL,NULL),(2,1,'Подключение API','ПA','Обновлённое API приложения',1,1,'2020-01-02 10:10:10',NULL,NULL,'2020-02-02 10:10:10',NULL,NULL,NULL);
/*!40000 ALTER TABLE `task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `task_status`
--

DROP TABLE IF EXISTS `task_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `task_status` (
  `Id` int NOT NULL,
  `Name` text NOT NULL,
  `Color_hex` varchar(15) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `task_status`
--

LOCK TABLES `task_status` WRITE;
/*!40000 ALTER TABLE `task_status` DISABLE KEYS */;
INSERT INTO `task_status` VALUES (1,'В работе','#07D100'),(2,'Открыта','#0006D1');
/*!40000 ALTER TABLE `task_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'taskmanager'
--

--
-- Dumping routines for database 'taskmanager'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-29 15:52:28
