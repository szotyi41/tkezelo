-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2017. Már 13. 07:54
-- Kiszolgáló verziója: 10.1.19-MariaDB
-- PHP verzió: 7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `database`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `epuletek`
--

CREATE TABLE `epuletek` (
  `epuletid` int(11) NOT NULL,
  `epulet` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `epuletek`
--

INSERT INTO `epuletek` (`epuletid`, `epulet`) VALUES
(1, 'Medve 19'),
(2, 'Bem 32'),
(3, 'Deák 23'),
(4, 'f'),
(5, 'fzth'),
(6, 'e'),
(7, 'sss'),
(8, 'qwer'),
(9, 'qwer');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `konyveles`
--

CREATE TABLE `konyveles` (
  `id` int(11) NOT NULL,
  `epuletid` int(2) NOT NULL,
  `datum` date NOT NULL,
  `megnevezes` varchar(25) CHARACTER SET utf8 NOT NULL,
  `bevetel` int(6) NOT NULL,
  `kiadas` int(6) NOT NULL,
  `egyenleg` int(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `konyveles`
--

INSERT INTO `konyveles` (`id`, `epuletid`, `datum`, `megnevezes`, `bevetel`, `kiadas`, `egyenleg`) VALUES
(1, 1, '2017-02-08', 'Kiadások', 0, 89000, -89000),
(2, 1, '2016-12-01', 'Költségvetés', 67900, 12500, 55400),
(4, 2, '2016-12-09', 'Felújítás', 19800, 17000, 2800),
(5, 2, '2016-12-01', 'Festés', 80000, 12000, 68000),
(6, 2, '2016-12-03', 'Juttatás', 12000, 0, 12000),
(7, 2, '2016-12-16', 'Nagy József', 96000, 27000, 69000),
(8, 2, '2016-12-06', 'OMAP Kft.', 0, 64000, -64000),
(9, 2, '2016-12-15', 'ELMŰ', 22340, 21200, 1140),
(10, 2, '2016-12-16', 'Szállítási költség', 12000, 16700, -4700),
(11, 2, '2016-12-10', 'Kazán karbantartás', 0, 19800, -19800),
(12, 2, '2016-12-24', 'Fénymásolás - NOKART kft.', 0, 46300, -46300),
(13, 2, '2016-12-20', 'Gallai Andrea', 102000, 0, 102000),
(14, 2, '2016-11-03', 'Takács Kornél', 96700, 0, 96700),
(15, 2, '2016-11-03', 'Festés', 0, 256000, -256000),
(16, 2, '2016-11-03', 'Farkas Oszkár', 32000, 0, 32000),
(17, 2, '2016-11-30', 'Nagy József', 35000, 0, 35000),
(18, 2, '2016-11-30', 'Juttatás', 19600, 0, 19600),
(19, 2, '2016-11-30', 'Fénymásolás - NOKART kft.', 0, 14000, -14000),
(20, 2, '2016-11-30', 'Gallai Andrea', 56000, 0, 56000),
(21, 2, '2016-11-03', 'Dr. Nagy Péter', 30960, 0, 30960),
(22, 1, '2016-12-13', 'Gál János', 87000, 0, 87000),
(23, 3, '2017-01-01', 'Építményadó', 32600, 0, 32600),
(24, 1, '2017-01-01', 'Juttatás', 12600, 0, 12600),
(25, 1, '2016-12-31', 'Felújítás', 0, 475000, -475000),
(33, 1, '2017-01-01', 'Felújítás', 0, 45000, -45000),
(34, 2, '2017-02-01', 'Felújítás', 2300, 0, 2300),
(42, 2, '2017-02-08', 'Kiadások', 0, 89000, -89000),
(43, 2, '2017-02-10', 'OTP', 12800, 0, 0),
(47, 2, '2016-12-16', 'Nagy József', 96000, 27000, 69000),
(48, 2, '2017-01-11', 'OTP', 0, 23000, -23000),
(51, 1, '2017-02-10', 'OTP', 12000, 256, 11744),
(52, 1, '2017-02-11', 'Társasház bevételek', 12300, 0, 12300),
(53, 1, '2017-02-13', 'Fent Mária', 32400, 0, 32400),
(54, 2, '2017-02-12', 'Nagy Oszkár', 54000, 0, 54000),
(55, 1, '2017-02-15', 'Felújítás', 302000, 120, 301880),
(56, 2, '2016-11-05', 'Pénzfelvétel', 84000, 0, 84000),
(57, 2, '2016-11-24', 'Bevételek', 32000, 0, 32000),
(72, 1, '2017-02-11', 'Almakompót', 111, 0, 111),
(73, 1, '2017-02-21', 'Körtepálinka', 0, 1222, -1222),
(80, 3, '2017-02-23', 'kecske', 22222, 0, 22222),
(83, 3, '2017-02-22', 'dwed', 333, 0, 333);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `nyomtatasok`
--

CREATE TABLE `nyomtatasok` (
  `nyomtatasid` int(11) NOT NULL,
  `megnevezes` varchar(50) NOT NULL,
  `szures` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- A tábla adatainak kiíratása `nyomtatasok`
--

INSERT INTO `nyomtatasok` (`nyomtatasid`, `megnevezes`, `szures`) VALUES
(17, 'Medve 19 - 2017. Február ', 'epulet LIKE ''%Medve 19%'' AND datum >= ''2017-02-01'' AND datum <= ''2017-02-27'' '),
(20, 'Bem 32 2017. Február ', 'epulet LIKE ''%Bem 32%'' AND datum >= ''2017-02-01'' AND datum <= ''2017-02-27'' '),
(21, 'Bem 32 2016. Február - 2017. Február ', 'epulet LIKE ''%Bem 32%'' AND datum >= ''2016-02-01'' AND datum <= ''2017-02-27'' '),
(22, 'Bem 32 2017. Január ', 'epulet LIKE ''%Bem 32%'' AND datum >= ''2017-01-01'' AND datum <= ''2017-01-30'' ');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `epuletek`
--
ALTER TABLE `epuletek`
  ADD PRIMARY KEY (`epuletid`);

--
-- A tábla indexei `konyveles`
--
ALTER TABLE `konyveles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Épület` (`epuletid`);

--
-- A tábla indexei `nyomtatasok`
--
ALTER TABLE `nyomtatasok`
  ADD PRIMARY KEY (`nyomtatasid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `epuletek`
--
ALTER TABLE `epuletek`
  MODIFY `epuletid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT a táblához `konyveles`
--
ALTER TABLE `konyveles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=84;
--
-- AUTO_INCREMENT a táblához `nyomtatasok`
--
ALTER TABLE `nyomtatasok`
  MODIFY `nyomtatasid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `konyveles`
--
ALTER TABLE `konyveles`
  ADD CONSTRAINT `konyveles_ibfk_1` FOREIGN KEY (`epuletid`) REFERENCES `epuletek` (`EpuletID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
