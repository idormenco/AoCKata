﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Kata
{
	class Program
	{
		public static void Main(string[] args)
		{
			//var wire1 = new List<string>() { "R991", "U557", "R554", "U998", "L861", "D301", "L891", "U180", "L280", "D103", "R828", "D58", "R373", "D278", "L352", "D583", "L465", "D301", "R384", "D638", "L648", "D413", "L511", "U596", "L701", "U463", "L664", "U905", "L374", "D372", "L269", "U868", "R494", "U294", "R661", "U604", "L629", "U763", "R771", "U96", "R222", "U227", "L97", "D793", "L924", "U781", "L295", "D427", "R205", "D387", "L455", "D904", "R254", "D34", "R341", "U268", "L344", "D656", "L715", "U439", "R158", "U237", "R199", "U729", "L428", "D125", "R487", "D506", "R486", "D496", "R932", "D918", "R603", "U836", "R258", "U15", "L120", "U528", "L102", "D42", "R385", "U905", "L472", "D351", "R506", "U860", "L331", "D415", "R963", "D733", "R108", "D527", "L634", "U502", "L553", "D623", "R973", "U209", "L632", "D588", "R264", "U553", "L768", "D689", "L708", "D432", "R247", "U993", "L146", "U656", "R710", "U47", "R783", "U643", "R954", "U888", "L84", "U202", "R495", "U66", "R414", "U993", "R100", "D557", "L326", "D645", "R975", "U266", "R143", "U730", "L491", "D96", "L161", "U165", "R97", "D379", "R930", "D613", "R178", "D635", "R192", "U957", "L450", "U149", "R911", "U220", "L914", "U659", "L67", "D825", "L904", "U137", "L392", "U333", "L317", "U310", "R298", "D240", "R646", "U588", "R746", "U861", "L958", "D892", "L200", "U463", "R246", "D870", "R687", "U815", "R969", "U864", "L972", "U254", "L120", "D418", "L567", "D128", "R934", "D217", "R764", "U128", "R146", "U467", "R690", "U166", "R996", "D603", "R144", "D362", "R885", "D118", "L882", "U612", "R270", "U917", "L599", "D66", "L749", "D498", "L346", "D920", "L222", "U439", "R822", "U891", "R458", "U15", "R831", "U92", "L164", "D615", "L439", "U178", "R409", "D463", "L452", "U633", "L683", "U186", "R402", "D609", "L38", "D699", "L679", "D74", "R125", "D145", "R424", "U961", "L353", "U43", "R794", "D519", "L359", "D494", "R812", "D770", "L657", "U154", "L137", "U549", "L193", "D816", "R333", "U650", "R49", "D459", "R414", "U72", "R313", "U231", "R370", "U680", "L27", "D221", "L355", "U342", "L597", "U748", "R821", "D280", "L307", "U505", "L160", "U982", "L527", "D516", "L245", "U158", "R565", "D797", "R99", "D695", "L712", "U155", "L23", "U964", "L266", "U623", "L317", "U445", "R689", "U150", "L41", "U536", "R638", "D200", "R763", "D260", "L234", "U217", "L881", "D576", "L223", "U39", "L808", "D125", "R950", "U341", "L405" };

			//var wire2 = new List<string>() { "L993", "D508", "R356", "U210", "R42", "D68", "R827", "D513", "L564", "D407", "L945", "U757", "L517", "D253", "R614", "U824", "R174", "D536", "R906", "D291", "R70", "D295", "R916", "D754", "L892", "D736", "L528", "D399", "R76", "D588", "R12", "U617", "R173", "D625", "L533", "D355", "R178", "D706", "R139", "D419", "R460", "U976", "L781", "U973", "L931", "D254", "R195", "U42", "R555", "D151", "R226", "U713", "L755", "U398", "L933", "U264", "R352", "U461", "L472", "D810", "L257", "U901", "R429", "U848", "L181", "D362", "R404", "D234", "L985", "D392", "R341", "U608", "L518", "D59", "L804", "D219", "L366", "D28", "L238", "D491", "R265", "U131", "L727", "D504", "R122", "U461", "R732", "D411", "L910", "D884", "R954", "U341", "L619", "D949", "L570", "D823", "R646", "D226", "R197", "U892", "L691", "D294", "L955", "D303", "R490", "D469", "L503", "D482", "R390", "D741", "L715", "D187", "R378", "U853", "L70", "D903", "L589", "D481", "L589", "U911", "R45", "U348", "R214", "D10", "R737", "D305", "R458", "D291", "R637", "D721", "R440", "U573", "R442", "D407", "L63", "U569", "L903", "D936", "R518", "U859", "L370", "D888", "R498", "D759", "R283", "U469", "R548", "D185", "R808", "D81", "L629", "D761", "R807", "D878", "R712", "D183", "R382", "D484", "L791", "D371", "L188", "D397", "R645", "U679", "R415", "D446", "L695", "U174", "R707", "D36", "R483", "U877", "L819", "D538", "L277", "D2", "R200", "D838", "R837", "U347", "L865", "D945", "R958", "U575", "L924", "D351", "L881", "U961", "R899", "U845", "R816", "U866", "R203", "D380", "R766", "D97", "R38", "U148", "L999", "D332", "R543", "U10", "R351", "U281", "L460", "U309", "L543", "U795", "L639", "D556", "L882", "D513", "R722", "U314", "R531", "D604", "L418", "U840", "R864", "D694", "L530", "U862", "R559", "D639", "R689", "D201", "L439", "D697", "R441", "U175", "R558", "D585", "R92", "D191", "L533", "D788", "R154", "D528", "R341", "D908", "R811", "U750", "R172", "D742", "R113", "U56", "L517", "D826", "L250", "D269", "L278", "U74", "R285", "U904", "L221", "U270", "R296", "U671", "L535", "U340", "L206", "U603", "L852", "D60", "R648", "D313", "L282", "D685", "R482", "U10", "R829", "U14", "L12", "U365", "R996", "D10", "R104", "U654", "R346", "D458", "R219", "U247", "L841", "D731", "R115", "U400", "L731", "D904", "L487", "U430", "R612", "U437", "L865", "D618", "R747", "U522", "R309", "U302", "R9", "U609", "L201" };


			////var wire1 = new List<string>() { "R98","U47","R26","D63","R33","U87","L62","D20","R33","U53","R51" };
			////var wire2 = new List<string>() { "U98","R91","D20","R16","D67","R40","U7","R15","U6","R7" };
			//var segments1 = PathToSegments(wire1);
			//var segments2 = PathToSegments(wire2);
			//var intersections = new List<Point>();
			//foreach (var s1 in segments1)
			//{
			//	foreach (var s2 in segments2)
			//	{
			//		if (DoIntersect(s1.start, s1.finish, s2.start, s2.finish))
			//		{
			//			var p = lineLineIntersection(s1.start, s1.finish, s2.start, s2.finish);
			//			if (p.X == 0 && p.Y == 0)
			//			{
			//				continue;
			//			}
			//			intersections.Add(p);
			//			Console.WriteLine($"({p.X} ,{p.Y})----->[{Math.Abs(p.X) + Math.Abs(p.Y)}]");
			//		}
			//	}
			//}

			////var intersection = new Point(-100,527);

			//foreach (var intersection in intersections)
			//{
			//	var d1 = PathToIntersection(wire1, intersection);
			//	var d2 = PathToIntersection(wire2, intersection);
			//	Console.WriteLine($"d1 = {d1} ,d2 = {d2}  sum ={d1 + d2}");

			//}

			//Console.WriteLine(HasOnlyIncreasingNumbers(123789));
			//Console.WriteLine(HasADoubleDigit(123789));
			
			//Console.WriteLine(CheckPasswordAgain(333444));
			//var count = Enumerable.Range(284639, 748759- 284639).Where(HasADoubleDigit).Where(HasOnlyIncreasingNumbers).Where(CheckPassword).Where(CheckPasswordAgain).Count();
			//var a = IntComputer.IntCodeOld(new int[]{ 1, 1, 1, 4, 99, 5, 6, 0, 99 });
			////var b = IntComputer.IntCodeNew(new int[] { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1102, 59, 58, 224, 1001, 224, -3422, 224, 4, 224, 102, 8, 223, 223, 101, 3, 224, 224, 1, 224, 223, 223, 1101, 59, 30, 225, 1101, 53, 84, 224, 101, -137, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 3, 224, 224, 1, 223, 224, 223, 1102, 42, 83, 225, 2, 140, 88, 224, 1001, 224, -4891, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 5, 224, 1, 223, 224, 223, 1101, 61, 67, 225, 101, 46, 62, 224, 1001, 224, -129, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 223, 224, 223, 1102, 53, 40, 225, 1001, 35, 35, 224, 1001, 224, -94, 224, 4, 224, 102, 8, 223, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1101, 5, 73, 225, 1002, 191, 52, 224, 1001, 224, -1872, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 5, 224, 1, 223, 224, 223, 102, 82, 195, 224, 101, -738, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 2, 224, 1, 224, 223, 223, 1101, 83, 52, 225, 1101, 36, 77, 225, 1101, 9, 10, 225, 1, 113, 187, 224, 1001, 224, -136, 224, 4, 224, 1002, 223, 8, 223, 101, 2, 224, 224, 1, 224, 223, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1007, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 329, 1001, 223, 1, 223, 1108, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 344, 101, 1, 223, 223, 1007, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 359, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 374, 1001, 223, 1, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 389, 1001, 223, 1, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 404, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 1008, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 434, 1001, 223, 1, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 449, 101, 1, 223, 223, 1008, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 464, 1001, 223, 1, 223, 8, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 479, 1001, 223, 1, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 494, 1001, 223, 1, 223, 7, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 509, 1001, 223, 1, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 524, 101, 1, 223, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 539, 101, 1, 223, 223, 8, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 554, 101, 1, 223, 223, 1107, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 569, 101, 1, 223, 223, 108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 584, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 599, 1001, 223, 1, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 614, 1001, 223, 1, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 629, 1001, 223, 1, 223, 1007, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 644, 101, 1, 223, 223, 1108, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 659, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 },1, 0);
			//var b = IntComputer.IntCodeNew(new int[] { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1102, 59, 58, 224, 1001, 224, -3422, 224, 4, 224, 102, 8, 223, 223, 101, 3, 224, 224, 1, 224, 223, 223, 1101, 59, 30, 225, 1101, 53, 84, 224, 101, -137, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 3, 224, 224, 1, 223, 224, 223, 1102, 42, 83, 225, 2, 140, 88, 224, 1001, 224, -4891, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 5, 224, 1, 223, 224, 223, 1101, 61, 67, 225, 101, 46, 62, 224, 1001, 224, -129, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 223, 224, 223, 1102, 53, 40, 225, 1001, 35, 35, 224, 1001, 224, -94, 224, 4, 224, 102, 8, 223, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1101, 5, 73, 225, 1002, 191, 52, 224, 1001, 224, -1872, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 5, 224, 1, 223, 224, 223, 102, 82, 195, 224, 101, -738, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 2, 224, 1, 224, 223, 223, 1101, 83, 52, 225, 1101, 36, 77, 225, 1101, 9, 10, 225, 1, 113, 187, 224, 1001, 224, -136, 224, 4, 224, 1002, 223, 8, 223, 101, 2, 224, 224, 1, 224, 223, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1007, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 329, 1001, 223, 1, 223, 1108, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 344, 101, 1, 223, 223, 1007, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 359, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 374, 1001, 223, 1, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 389, 1001, 223, 1, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 404, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 1008, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 434, 1001, 223, 1, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 449, 101, 1, 223, 223, 1008, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 464, 1001, 223, 1, 223, 8, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 479, 1001, 223, 1, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 494, 1001, 223, 1, 223, 7, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 509, 1001, 223, 1, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 524, 101, 1, 223, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 539, 101, 1, 223, 223, 8, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 554, 101, 1, 223, 223, 1107, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 569, 101, 1, 223, 223, 108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 584, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 599, 1001, 223, 1, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 614, 1001, 223, 1, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 629, 1001, 223, 1, 223, 1007, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 644, 101, 1, 223, 223, 1108, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 659, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 },5, 0);
			//Console.WriteLine(string.Join(",",b));

			List<string> orbits = new List<string>()
			{
				"NKB)PZS",
"KBG)9JH",
"PZS)KZD",
"8J1)GT7",
"7HT)9ZM",
"RV2)14G",
"RM1)YG7",
"36C)BPH",
"BY7)5RG",
"PYW)RWT",
"VHV)DCN",
"8GP)3DJ",
"PWQ)KNW",
"WRQ)R4M",
"PYK)WQ7",
"C47)RSZ",
"KVF)879",
"M8B)TRX",
"RL1)N46",
"H7D)5CD",
"FZM)T6P",
"99X)DN8",
"1M7)ZWZ",
"2XZ)C9G",
"K9Q)CLK",
"KVF)WGY",
"S2F)3XK",
"LRC)DHQ",
"3VV)549",
"XFJ)YV2",
"764)7PZ",
"RV2)2G9",
"CGP)CZ5",
"PZP)WLC",
"NKB)ZLV",
"6YS)WHG",
"547)HYD",
"CPP)GNM",
"LNZ)T4D",
"WLC)55F",
"GNP)5XG",
"RT1)TP3",
"223)51G",
"GDY)2DF",
"CDN)9CS",
"JVW)N4N",
"4C4)FYN",
"C27)3NK",
"R1Z)ZD9",
"2RV)4GR",
"YR3)H8J",
"67C)46J",
"RQP)35J",
"T3G)FTR",
"QHT)8JG",
"JML)H46",
"74P)KTH",
"SC9)CDN",
"633)WRD",
"6WJ)NZQ",
"JQS)QHT",
"FHW)QL9",
"347)XLW",
"H25)5QX",
"M6Y)MTC",
"F1D)XZN",
"NJ6)D26",
"NHJ)B87",
"8H5)FF9",
"DNL)9K9",
"JM7)GNN",
"BRD)JGW",
"WGH)VM1",
"T4F)33Y",
"MC6)7M9",
"LKQ)N5L",
"WGY)Q4F",
"XL4)SD8",
"N7W)J59",
"TDX)8N3",
"M9S)64V",
"NNT)WPY",
"C9G)RSM",
"J8M)WDS",
"5X4)346",
"KGG)TZR",
"4LY)JST",
"5MM)MCX",
"PG8)6S4",
"G4R)NNT",
"FYY)SFS",
"Q1B)MLQ",
"N9F)B7F",
"B5F)452",
"57Y)TQ3",
"NCC)2ZZ",
"XQ2)18R",
"G7V)7SQ",
"93T)SR1",
"T1X)9WB",
"46W)GDY",
"Q74)RP1",
"B1F)GV4",
"KR9)Q1J",
"ZZZ)4NL",
"7PZ)NSK",
"G5Q)KCQ",
"6K7)2W6",
"GRL)VTL",
"RWY)G7B",
"LB4)DT4",
"QZW)51L",
"NV5)D8H",
"49G)4NQ",
"XZC)4RB",
"Y9S)7XV",
"4GT)N9M",
"39K)7X1",
"W83)JQR",
"547)KLC",
"4GT)2LM",
"S4F)RN9",
"BBL)47N",
"JYJ)W2D",
"F16)3H9",
"K5F)1XC",
"JPY)6RY",
"9TW)5X1",
"9QS)P5L",
"CZ7)PZ6",
"R3X)M6Y",
"JQ6)CN3",
"R3M)PTR",
"X6Y)8RW",
"YB8)X6L",
"HZQ)GRL",
"P5J)DNS",
"7C1)SX8",
"JF5)72W",
"MYG)XZC",
"BRD)5XK",
"QJV)P4N",
"SKC)7BF",
"67C)PXD",
"LCC)7R1",
"BMC)BCT",
"WW3)145",
"W4D)VT3",
"8L2)W4W",
"M85)GQ4",
"P77)HZ2",
"DN1)1P2",
"493)6R8",
"2K4)NZL",
"NZ5)NV5",
"SBZ)W7Q",
"SMT)DP7",
"L5H)BMC",
"W7Q)K7X",
"3QT)GPV",
"ZDQ)KQ6",
"8LG)PNS",
"3XG)3XT",
"KFQ)X3K",
"3QT)D9X",
"PL5)WH6",
"PYX)HNG",
"D7G)VC5",
"NM2)39K",
"RRN)LZ5",
"342)V9B",
"1F5)S8L",
"WHG)LS5",
"3D3)XSD",
"1J9)MNR",
"LNH)LBK",
"MZR)L5P",
"M3T)333",
"X4N)7VX",
"SCH)VJP",
"5XJ)CMS",
"CBY)DQD",
"PWQ)VZB",
"1H9)8H5",
"MFN)C29",
"PLY)VQ3",
"GQP)T85",
"K7X)891",
"JZD)HLQ",
"FMM)D9Z",
"P85)T1Y",
"NWJ)764",
"L5P)VWM",
"MVS)9TW",
"VQ6)P3D",
"CXV)L2K",
"46J)3PL",
"SDY)VQ6",
"8LT)77D",
"8GR)XBF",
"17Z)NRH",
"T9T)3KD",
"D9Z)49G",
"BFV)HMX",
"XBF)L28",
"BDT)LWN",
"6R8)B8J",
"G1V)9VK",
"V9B)VSQ",
"WKG)4GD",
"879)ZHH",
"SFS)VR7",
"B2H)88T",
"8HB)XMH",
"YSN)Z5G",
"G8R)HP2",
"KHT)57D",
"RS2)74P",
"4Q9)KG8",
"G85)33L",
"FJH)CSD",
"5Z8)JQS",
"WPX)6XQ",
"LNZ)5GG",
"PVS)Y28",
"253)5Z8",
"KMP)8ZL",
"16H)GXP",
"47N)JQ6",
"SX8)PHF",
"WM1)JPY",
"TRS)8KG",
"W7Q)S83",
"QWL)ZXH",
"SQ4)KJ7",
"J2S)5ZY",
"51G)CGP",
"HZ2)VL2",
"5PL)WGR",
"QTY)LYQ",
"8TJ)2BP",
"MJK)RW8",
"P4N)F7R",
"KPS)JJJ",
"KYX)7S3",
"VTL)4QW",
"2LM)BS2",
"YDH)M1H",
"VL2)5MH",
"99P)B3C",
"33Y)QG3",
"RWT)K4F",
"M4J)8FL",
"QL5)RT3",
"8QT)RV2",
"R6Y)MFN",
"ZFT)KSJ",
"CSD)W8J",
"WH6)PZP",
"7S3)KZX",
"5LK)QC5",
"VT3)9XG",
"6H4)F6S",
"VR7)W4D",
"43J)4X6",
"638)389",
"PVT)QWL",
"GG4)BFL",
"D87)SC9",
"KVS)NN1",
"81W)NP7",
"Z4K)RM1",
"5XK)KND",
"CZ5)GXC",
"WCZ)NHP",
"ZBC)5PL",
"RSM)DQG",
"L9Q)4LY",
"QQY)5BK",
"1Z6)JKF",
"6XQ)ZPT",
"T57)HHX",
"DB4)8L2",
"DNS)M85",
"T4V)XD4",
"VY3)9NQ",
"59V)F1D",
"PZ6)HXZ",
"P5L)F49",
"XMF)LNH",
"472)FBN",
"8G2)372",
"959)93T",
"97T)H13",
"2W6)4R9",
"D26)LKQ",
"34D)F6Q",
"NZ5)THG",
"D36)HX3",
"Z9P)QKJ",
"G1X)V8D",
"7WF)MVS",
"N6J)Z1L",
"Y3Q)JZY",
"VJP)9PF",
"ZNV)BZ6",
"V8D)DKJ",
"R7K)GHD",
"6D7)GNP",
"BHN)F24",
"Y32)YSW",
"MJD)T4Z",
"54M)H8Y",
"NWJ)5XT",
"LQ2)99P",
"LR8)D2R",
"JZD)ZWG",
"LDC)R9L",
"FF9)CMM",
"NWL)Q5R",
"11B)Q2Q",
"Q1J)V81",
"YSW)JDJ",
"KYX)S5R",
"6SK)6Y4",
"S8L)1H9",
"DCB)142",
"6RW)995",
"777)J13",
"QN7)83F",
"5NL)SC3",
"DTY)15Z",
"Q85)R3T",
"XZN)YH4",
"XB9)6RB",
"GV4)5RV",
"6F3)V9P",
"CN3)TLT",
"2BP)9CW",
"Q8R)SYP",
"Z5V)GX4",
"7ND)2XZ",
"8PS)7D7",
"1R9)T4F",
"ZWZ)QL4",
"KPM)Z32",
"3XK)1F5",
"87K)FNM",
"TFQ)L5J",
"9QQ)K5F",
"KCQ)717",
"KQV)16H",
"PJ9)MW1",
"35J)ZMQ",
"LFD)CR6",
"XGK)9QQ",
"ZWG)K2F",
"DXR)31S",
"46R)XZM",
"C29)T57",
"8J2)66C",
"83F)SSF",
"ZHN)JKT",
"N46)ZNV",
"7SQ)P2N",
"XK3)839",
"ZH8)7LG",
"D45)PMJ",
"QNN)QGN",
"NSJ)54M",
"F8H)KJD",
"COM)1Z6",
"3T1)H1Z",
"31D)XGK",
"3R5)3CF",
"YB2)KPS",
"JJJ)57Y",
"RPZ)W43",
"VV1)M8D",
"7WF)5XR",
"BG5)GBM",
"RT3)C18",
"TSX)31B",
"46C)RRN",
"J3X)PFZ",
"2FG)MPX",
"W4W)2V1",
"JWZ)Q8R",
"8CF)DN1",
"MLQ)81P",
"DMN)SM7",
"D1D)8TJ",
"XVW)RWY",
"KQ6)Y91",
"M3P)HY7",
"VDR)1ZS",
"SXD)J9M",
"Q51)7C4",
"Z1X)3N1",
"PXD)QVX",
"T81)942",
"7C4)2Y3",
"DMN)6YS",
"KMD)T28",
"15H)KSF",
"2DF)FJH",
"86S)R8G",
"WRD)YB8",
"G58)7C1",
"6WR)C23",
"BK9)LMM",
"HP2)2BY",
"FZ3)H2C",
"TJC)BBL",
"9YQ)L9N",
"4VR)DZ4",
"PP1)P65",
"YG7)BZH",
"QKJ)QB7",
"R3G)FZ3",
"XF7)D45",
"47N)PL5",
"PVT)KHT",
"HXZ)X6Y",
"LK2)QBF",
"6WJ)7ND",
"7D5)KLK",
"346)R24",
"551)Z4K",
"CZN)QN7",
"BGP)FBY",
"4X6)LCX",
"31B)DQF",
"N9M)S2S",
"DP7)8M2",
"4TC)GJT",
"GJZ)JHD",
"QHB)W8V",
"88T)N47",
"452)S8Q",
"V2B)SCH",
"VYJ)N75",
"4VJ)XRS",
"VM9)1VD",
"HX3)D78",
"SZ4)Q74",
"TLQ)G8R",
"29Y)YSN",
"NGK)14N",
"B4J)XF2",
"NWY)F8H",
"47X)D1D",
"QF5)QYX",
"K2F)G81",
"31S)MF8",
"L19)SJN",
"KTH)LLF",
"FMT)JF5",
"XW3)Y32",
"ZB7)CW4",
"5BF)RCX",
"WF8)756",
"ZXK)36C",
"3KD)VRR",
"MJB)HRY",
"F8T)7LQ",
"5XG)9SV",
"T34)H3W",
"1WQ)BZ7",
"TS8)8BC",
"8LF)69Q",
"615)R9C",
"SB8)W8P",
"612)BGP",
"9SV)M1T",
"SFS)PJ9",
"FYN)66G",
"1LF)YQ5",
"WLV)JM7",
"6XL)Z84",
"CT9)SZ4",
"2V1)V2B",
"8PS)6K7",
"9ZM)3VM",
"JYP)6TT",
"MPX)ZB7",
"9BM)M9S",
"CMM)KNC",
"X27)DMN",
"SR1)ZSF",
"59V)ZSD",
"JKF)DB4",
"B3V)X6K",
"RG4)DMB",
"9Z5)TZ8",
"T28)BS7",
"T8M)KGD",
"CQR)JZD",
"5QD)2M3",
"K8F)L19",
"XF2)GNL",
"MP5)12X",
"MFK)MJD",
"BGR)HCD",
"GPV)F32",
"2Y3)RBD",
"GQ4)F2S",
"342)G5Q",
"2BR)81W",
"6S4)46W",
"ZLV)TRS",
"WSD)9ZN",
"1TS)9MZ",
"VW9)YOU",
"XWM)M7F",
"VRR)G68",
"JFZ)X27",
"32L)HSW",
"D5V)M3T",
"HQF)G8W",
"N5L)MFK",
"27Z)NWL",
"H2C)M8B",
"HVP)B5F",
"DN8)P85",
"RP1)C5Y",
"8KG)75C",
"3M4)XL4",
"3B2)WCZ",
"X8Z)Y9D",
"NZQ)HCV",
"142)Y3Q",
"14G)3GJ",
"X8L)SKC",
"RTJ)JX8",
"ZFD)G8P",
"G8W)3T5",
"F7K)SL3",
"9VK)BFV",
"PHF)55C",
"RND)TVX",
"WSS)4GT",
"MHR)G35",
"8KQ)1Q8",
"JMF)G85",
"R24)H67",
"CZ7)65P",
"NDQ)Z93",
"QG3)L4J",
"QC5)GVX",
"711)2ZQ",
"Z32)BY7",
"T1Y)547",
"WK8)RFD",
"KGZ)2FG",
"51G)551",
"H8Y)GNW",
"GT7)XMF",
"JLZ)G9H",
"RZH)QBB",
"TZX)X54",
"6HT)N4W",
"FNM)FFD",
"PCG)SZD",
"4GN)SBT",
"BBL)F6Z",
"CWC)XJ9",
"W9D)NZ5",
"KNW)SSV",
"D2R)KWC",
"3H9)FCY",
"145)B8Z",
"TYT)3FH",
"6W9)BGR",
"5MH)L9Q",
"2CD)VYJ",
"6V2)JZ2",
"QBF)J4X",
"XH1)X8R",
"NN1)ZNF",
"ZX9)DHP",
"M7F)V12",
"TVX)NJC",
"4LQ)YY7",
"3VM)R7K",
"KCP)MYG",
"YH4)8LF",
"TP3)4MC",
"CN9)MRC",
"PJ9)NK2",
"RBW)VP8",
"XLW)T68",
"QL9)QNN",
"DQF)LW6",
"GHD)MRY",
"S53)638",
"839)X8L",
"7WG)KV4",
"33L)ZBC",
"LTY)HPV",
"T4D)PVT",
"WMQ)WRQ",
"DJ3)347",
"3RJ)1KL",
"QVX)SXD",
"LQW)JLZ",
"6YQ)XB9",
"L2K)Y9K",
"TH1)9PW",
"ZMB)6HF",
"15K)9YQ",
"1JD)4TJ",
"35P)PG8",
"H63)1HW",
"TGV)6QV",
"TZR)6D7",
"VM1)6MW",
"7LG)WVQ",
"8LX)MDS",
"4L5)DCB",
"Q5R)1LR",
"G8P)RPZ",
"8FX)ZQ2",
"WST)NMF",
"452)L6D",
"SL3)Z5V",
"BFK)K3W",
"KGD)PLY",
"8M2)DXW",
"JKZ)47X",
"VV5)HLF",
"8MM)QQ2",
"XSD)CZN",
"7XV)D8Q",
"MRD)HZQ",
"N29)DP8",
"MS4)35L",
"G8H)RD3",
"QL6)7Z8",
"SZ6)RH5",
"9HW)H9D",
"SJN)LLP",
"KSR)27Z",
"H46)G7V",
"K9L)P46",
"QDL)633",
"66C)2Z9",
"PP1)PYW",
"W8V)RYK",
"HL5)NGK",
"18R)Y9S",
"DL9)RJK",
"LWN)KYX",
"HJT)RL1",
"BLY)342",
"6TP)LJ2",
"ZG8)SKB",
"25Y)KHV",
"K8X)Y95",
"1L5)3D3",
"DWW)T3G",
"1P2)BMB",
"XRS)NJ6",
"K4F)M4J",
"P2N)KRT",
"4N8)57V",
"WLS)3R5",
"RCX)9HW",
"7K8)T34",
"D9X)MZR",
"9ZN)4X7",
"RZ4)LQ2",
"JKT)JGF",
"LW4)7HT",
"D8Q)281",
"8BC)ZDQ",
"SJN)BRD",
"5NL)RX9",
"3G7)D87",
"9K9)BR9",
"7X1)T4V",
"65P)V3M",
"845)1L5",
"8P7)XPF",
"G8H)WLS",
"SRB)2P2",
"QB7)G8H",
"DKJ)LB4",
"3DJ)D36",
"8JG)ZX9",
"RMX)SLV",
"RQC)QZW",
"58D)JYJ",
"THG)GG4",
"5CD)YQN",
"Y28)FWP",
"78H)8LP",
"XDF)KMD",
"LYT)CFR",
"281)2M2",
"2N1)W9D",
"6R7)6SK",
"42D)8NV",
"KRT)6YQ",
"RP8)W83",
"SBT)DNL",
"MMY)TLQ",
"GNM)R3M",
"8PV)YDH",
"6PL)5Y8",
"8RW)11B",
"HG2)Q1B",
"XYR)GGV",
"K4J)35X",
"RSZ)Z56",
"56R)P9X",
"P9X)96H",
"H63)4QK",
"XMH)WMQ",
"3VP)6R7",
"F32)MP5",
"ZMB)PLP",
"B7H)26Y",
"TLT)KFQ",
"VJ5)223",
"5ZP)8KQ",
"GXP)T8M",
"6TT)LH9",
"XSW)LFD",
"RBD)612",
"KQW)V3W",
"MNR)9FZ",
"W8J)ZHS",
"4PT)ZHN",
"MHG)8YQ",
"J9M)B25",
"KGG)845",
"Y81)SAN",
"3NK)RDX",
"7Z8)SG7",
"4NQ)PP1",
"RYK)5LK",
"VWM)7SC",
"KXZ)1J9",
"KSY)YJM",
"KSJ)Q51",
"ZQ2)8LG",
"F24)6WJ",
"Q4F)KQX",
"BPH)C27",
"2M2)JML",
"6QV)QTY",
"F3Z)2NF",
"JRS)TH1",
"RH5)34D",
"GNV)493",
"QMY)Y5G",
"2NF)R34",
"N4N)JWZ",
"LH9)TSX",
"SJG)8Z2",
"NRH)H63",
"YGZ)6L9",
"NP7)7L6",
"RY7)MS4",
"55F)HW4",
"GCP)8LT",
"YQH)QJV",
"GH5)T76",
"RVC)R3X",
"PRG)B1F",
"8N3)631",
"J59)WFN",
"JLH)15H",
"QNN)6H4",
"2K9)LK2",
"S8Q)T81",
"DHP)SBZ",
"69Q)SW1",
"J7G)KGG",
"GBM)D4T",
"35X)GWC",
"LQW)5ZP",
"9PW)QMY",
"YY7)VV1",
"SD8)XDF",
"TNH)9YX",
"3CF)X8J",
"1S8)Q85",
"YJM)LQW",
"SVZ)2JH",
"FFD)D9L",
"CN9)M3P",
"KG8)JLH",
"YTC)F17",
"JHD)LCC",
"372)LR8",
"PZP)8J2",
"5Y8)HL5",
"DCN)MJK",
"HNG)QNX",
"NHP)SB9",
"4DQ)GYD",
"84T)3G5",
"5RV)LT2",
"GXC)ZG8",
"8ZL)G4R",
"Q82)XN5",
"HQ8)KMF",
"F2S)777",
"L9Q)K4J",
"N7Y)KCP",
"M6Y)JVW",
"7LM)Y99",
"418)5MM",
"12X)LYT",
"1KL)J8M",
"JQR)3V7",
"VQ3)K11",
"TQ3)TZP",
"2M3)G1P",
"C23)DWW",
"2G9)RVC",
"GJT)KW6",
"Z32)BLY",
"K11)J9Y",
"Z84)4Z4",
"V3M)G1V",
"BMT)5NL",
"DQF)78C",
"6R7)WSS",
"LLF)QF5",
"9HP)X4N",
"P46)J12",
"FRL)YV3",
"KND)L5H",
"SSF)WLV",
"M8B)1S8",
"YDZ)RT8",
"B87)TJC",
"WQ7)PYX",
"CW3)87K",
"45Q)MQ5",
"VH4)3JY",
"TFB)S53",
"KQX)GFM",
"H3W)BNH",
"KGD)MJB",
"995)8GR",
"ZSD)B2H",
"75C)XF7",
"W29)3VP",
"2GY)GTN",
"SY3)XRB",
"Y5G)VYP",
"JGW)R7Y",
"DP2)PVS",
"999)6W9",
"XD4)7GJ",
"TSW)C1Y",
"R34)MMY",
"5BK)9SL",
"51L)G1X",
"VC5)9P5",
"8J1)K9L",
"WFD)15K",
"LCX)NSJ",
"ZD9)Y1J",
"38S)3VV",
"4HD)NPY",
"79C)1M7",
"5LK)8G2",
"D9L)LCZ",
"QD5)84Z",
"RL1)VY3",
"BBH)6QK",
"BGD)XYR",
"N47)KBG",
"S83)DJ3",
"4CC)NKB",
"BPX)TZX",
"HLF)8GW",
"3KB)KMP",
"LJ2)LPV",
"3H3)RQC",
"KGT)615",
"KMF)DP2",
"BZ7)JYP",
"GX4)MD5",
"GJZ)WKG",
"MTC)TSW",
"7D7)P5J",
"HGR)ZZZ",
"4MC)86S",
"RJW)35P",
"W8P)XH1",
"VZB)G1J",
"JRC)YTC",
"6MW)KSR",
"QMY)45Q",
"F6S)3VZ",
"631)YB2",
"VWN)MC6",
"YV3)B8K",
"Q76)1HB",
"PN4)XW3",
"NJC)ZFT",
"4XQ)KSY",
"MRY)9KV",
"S8L)BL8",
"BR9)711",
"R8G)J1S",
"57V)4HD",
"68Q)W6C",
"HHL)CRM",
"RWV)VH4",
"9KC)NHG",
"F6Q)3KB",
"NN4)C9K",
"5X1)FHW",
"6Y4)171",
"7M9)9RW",
"5RG)N29",
"LYQ)5X4",
"PFZ)QDL",
"V3W)2F6",
"YQ5)ZH8",
"9FM)L64",
"H8J)BLH",
"1Q8)7K8",
"7SC)6TS",
"Y29)F8T",
"RFD)VM9",
"N75)2K4",
"CW4)51C",
"524)MRD",
"WFN)Y29",
"LMM)JRC",
"8NV)YNF",
"R7Y)XVW",
"HRY)DNT",
"C6Z)RS2",
"7S3)D3M",
"T6P)XFJ",
"SC3)Q7P",
"JGF)H82",
"SB8)9MF",
"8LD)6HT",
"KNC)XQ2",
"GTN)G9M",
"PCD)6XS",
"MZR)RG4",
"GDY)FXJ",
"KHV)BG5",
"5XT)CZ7",
"SBL)GJB",
"X3K)YDZ",
"77D)7CB",
"2JH)VP3",
"4FC)SGM",
"PG2)HDH",
"H25)Z3K",
"9XG)GJZ",
"891)DR5",
"BR8)22Y",
"XPF)L83",
"NK2)JMF",
"717)7CL",
"B3C)PCG",
"R4M)HHL",
"BLH)KVF",
"4GR)K8X",
"DXW)58D",
"4R9)84T",
"LS5)6F3",
"Z56)WM1",
"J9M)LRC",
"P3D)DXR",
"NZQ)4XQ",
"549)TYT",
"2BY)68Q",
"ZXH)S9G",
"BS2)WPX",
"4JP)JG9",
"RDX)WW3",
"LRC)199",
"QZW)8P7",
"RLP)DQV",
"JLZ)8GP",
"FXJ)S9H",
"N4W)524",
"9WB)S64",
"142)PN4",
"R34)FZM",
"L9N)9Z5",
"D1W)S5B",
"C9K)SZ6",
"B25)C47",
"9PF)RND",
"FZM)Z9P",
"L64)8QT",
"4Z4)CBY",
"XFL)Y5Y",
"W2D)VW9",
"V6D)N9F",
"SYP)5TW",
"S5R)KPM",
"QYX)T1X",
"MW1)2RV",
"DZ4)6TP",
"P64)P73",
"PZ6)JRN",
"JRC)CNR",
"RYF)Z2Z",
"MF8)FDB",
"2ZZ)XL3",
"LBK)B7H",
"15Z)17Z",
"3W8)K8F",
"BZ6)RJW",
"G1J)CBR",
"2N9)SVF",
"NSK)253",
"78X)1MZ",
"3TH)BGD",
"15K)2K9",
"BS7)CGB",
"BGR)XSW",
"4GD)CPP",
"RX9)WK8",
"RJK)VWN",
"9RW)N6J",
"J4X)4C4",
"35L)1WQ",
"HZ2)QL6",
"RND)VJ5",
"2Z9)76C",
"Z2Z)YB4",
"JNP)8MM",
"Z1L)SRB",
"3VZ)NHJ",
"8GW)56R",
"C1Y)8LX",
"4QW)XK3",
"G68)SQ4",
"Y9D)HQF",
"T85)38S",
"Y9K)9FM",
"RD3)RWV",
"F17)B8P",
"HMG)1JD",
"T8M)46C",
"JC8)HJT",
"D8H)F6K",
"55C)3BM",
"TZ8)VDR",
"FBY)BDT",
"CNR)4JP",
"GMJ)CW3",
"G9M)TGV",
"G81)ZSQ",
"C5Y)MHR",
"6RB)99X",
"9JH)F16",
"G5F)VFV",
"T1L)2N1",
"L6D)9QS",
"LT2)97T",
"CGB)RS9",
"HW4)WSD",
"22Y)7LM",
"PKQ)CN9",
"LPV)H25",
"LLP)SJ1",
"LCZ)SB8",
"CR6)DFJ",
"VV1)RLP",
"S9G)PWQ",
"9FZ)3TH",
"X9R)4R4",
"6TS)RFG",
"GNL)RZ4",
"HCV)8CF",
"KZD)3W8",
"DR5)F3Z",
"1R2)8FX",
"G5W)MHG",
"TL3)TDX",
"HPV)1R9",
"NMF)67C",
"LW6)N7W",
"LB9)KQV",
"DMB)25Y",
"9MF)B9K",
"DP8)43J",
"ZHS)1LW",
"Q51)HQ8",
"H9D)SJG",
"RW8)PKQ",
"6XS)FYY",
"YV2)WGH",
"KLK)9BM",
"TZP)PYK",
"M41)4TC",
"GFM)418",
"CW4)HGF",
"K3W)T9T",
"H1Z)GBK",
"VFV)XXH",
"Q7R)6V2",
"L5J)TL3",
"LYT)29Y",
"HLQ)HG2",
"9YX)HMG",
"NJ6)X1P",
"CRM)RYF",
"8GW)D1W",
"6L9)G58",
"DT4)ZMB",
"QWL)BMT",
"9SV)WST",
"ZPT)LB9",
"3G5)W92",
"199)F7K",
"WGR)794",
"F6Z)HGR",
"NW9)ZFD",
"V4S)Y81",
"XRB)BFK",
"5XR)TS8",
"6HT)B4J",
"6XQ)SY3",
"6HF)PRG",
"78C)D5V",
"4X7)FRL",
"GYD)JNP",
"2F6)QD5",
"T68)GH5",
"Z93)P64",
"G35)4Q9",
"5ZY)32L",
"M8D)46R",
"WVQ)J7G",
"8FL)Q82",
"KWC)K9Q",
"1ZS)WF8",
"84Z)T1L",
"ZSQ)MMQ",
"MC6)78H",
"C6Z)J3X",
"Y91)RBW",
"WPY)Q7R",
"GVX)VHV",
"CW3)W29",
"TRX)KL8",
"1LR)3B2",
"XL4)LNZ",
"FDB)79C",
"X6K)S4F",
"HDH)S2F",
"Y1J)CQR",
"5ZP)GMJ",
"QQ2)7WF",
"YJM)GQP",
"DQV)RQP",
"KLC)Z1X",
"Q7P)R1Z",
"PLP)2GY",
"7VX)7WG",
"G1X)VV5",
"H3G)KQW",
"FCY)RY7",
"333)QHB",
"VV5)8PS",
"X6L)TNH",
"QGN)NW9",
"YNF)QL5",
"XDF)CXV",
"F6K)9KC",
"G7B)YKY",
"Y99)4CC",
"J1S)SMT",
"4R4)NCC",
"Z3K)BHN",
"CBR)4VJ",
"L4J)N2C",
"1L5)G5W",
"3JY)KGT",
"1LW)4L5",
"XZM)5XJ",
"MQ5)M41",
"7BF)3QT",
"756)9HP",
"GNW)1LF",
"CLK)JC8",
"SGM)V4S",
"BCT)XFL",
"B8Z)1T4",
"2V1)BK9",
"FWP)PP8",
"L83)4C5",
"C18)KH1",
"HHX)KGZ",
"1XC)6XL",
"QBB)SBL",
"GHD)LTY",
"5XJ)2TJ",
"4CC)BPX",
"6YQ)4LQ",
"HGF)3RJ",
"6QK)QQY",
"VP8)31D",
"V9B)GNV",
"YR3)472",
"4C5)YGZ",
"389)ZXK",
"3BM)QWB",
"WH7)JKZ",
"9NQ)42D",
"S2S)X8Z",
"S9H)4N8",
"R9L)T9D",
"3T1)JRS",
"W92)4DQ",
"8K7)2N9",
"8LP)8LD",
"5GG)3T1",
"M1T)WH7",
"GBK)8PV",
"X54)3H3",
"7C1)QZ8",
"KQ6)KVS",
"7L6)NWJ",
"51L)R3G",
"DHQ)3M4",
"DNT)YQH",
"HCD)6PL",
"3N1)3G7",
"YKY)3XG",
"B8J)J2S",
"P73)278",
"9P5)TFQ",
"Z5G)PCD",
"3PL)B3V",
"X8R)NWY",
"S5B)YR3",
"CFR)LMD",
"SKB)DK6",
"BFL)78X",
"CWQ)NDQ",
"9LQ)N7Y",
"JST)6RW",
"RN9)RZH",
"V9P)V6D",
"4TJ)8J1",
"9KC)NM2",
"9CW)CWC",
"KTH)1R2",
"WDS)4PT",
"JZ2)RTJ",
"1HW)4VR",
"942)LDC",
"278)FMT",
"794)KR9",
"84T)H7D",
"CMS)G5F",
"V81)1TS",
"V12)2BR",
"TRS)BBH",
"8Z2)8K7",
"JRN)CT9",
"B8P)SVZ",
"KSF)RP8",
"QNX)SDY",
"LMD)DTY",
"9MZ)BR8",
"4RB)8HB",
"X8J)5BF",
"KZX)9LQ",
"JX8)DL9",
"2P2)H3G",
"H67)C6Z",
"66G)59V",
"KL8)HVP",
"D3M)TFB",
"HY7)FMM",
"SW1)RMX",
"GJB)NN4",
"B7F)4GN",
"XXH)ZCP",
"XJ9)XWM",
"9QQ)X9R",
"RS9)2CD",
"G1P)4FC",
"QL4)RT1",
"7LM)CWQ",
"5TW)Q76",
"9LQ)P77",
"3XT)2T6",
"RFG)PYJ",
"JZY)D7G",
"KJ7)LW4",
"VSQ)999",
"SVF)WFD",
"51C)959",
"NZL)JFZ",
"81P)27W",
"P64)6WR",
"D9Z)KXZ",
"X1P)TXH",
"ZSF)5QD",
"HYD)R6Y",
"ZNF)7D5",
"J12)PG2",
"BL8)GCP"
			};

			List<string> l2 = new List<string>()
			{
				"COM)B",
				"B)C",
				"C)D",
				"D)E",
				"E)F",
				"B)G",
				"G)H",
				"D)I",
				"E)J",
				"J)K",
				"K)L",
				"K)YOU",
				"I)SAN"
			};


			var tree = Orbit.Parse(orbits);
			Console.WriteLine(Orbit.GetTotalNumberOfJumps(tree));
		}
	}
}
