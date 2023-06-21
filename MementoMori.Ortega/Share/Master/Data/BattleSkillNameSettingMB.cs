﻿using System.ComponentModel;
using MementoMori.Ortega.Share.Enums;
using MementoMori.Ortega.Share.Master.Attributes;
using MessagePack;

namespace MementoMori.Ortega.Share.Master.Data
{
	[Description("バトルスキル演出設定")]
	[MessagePackObject(true)]
	public class BattleSkillNameSettingMB : MasterBookBase
	{
		[Description("アクティブスキルID(ActiveSkillMB)")]
		[PropertyOrder(1)]
		public long ActiveSkillId
		{
			get;
		}

		[Description("改行位置設定 JP")]
		[PropertyOrder(2)]
		public int NewLineIndexJP
		{
			get;
		}

		[PropertyOrder(3)]
		[Description("改行位置設定 US")]
		public int NewLineIndexUS
		{
			get;
		}

		[PropertyOrder(2)]
		[Description("改行位置設定 KR")]
		public int NewLineIndexKR
		{
			get;
		}

		[PropertyOrder(3)]
		[Description("改行位置設定 TW")]
		public int NewLineIndexTW
		{
			get;
		}

		[SerializationConstructor]
		public BattleSkillNameSettingMB(long id, bool? isIgnore, string memo, long activeSkillId, int newLineIndexJP, int newLineIndexUS, int newLineIndexKR, int newLineIndexTW)
			:base(id, isIgnore, memo)
		{
			ActiveSkillId = activeSkillId;
			NewLineIndexJP = newLineIndexJP;
			NewLineIndexUS = newLineIndexUS;
			NewLineIndexKR = newLineIndexKR;
			NewLineIndexTW = newLineIndexTW;
		}

		public BattleSkillNameSettingMB():base(0, false, "")
		{
			/*
An exception occurred when decompiling this method (0600349F)

ICSharpCode.Decompiler.DecompilerException: Error decompiling System.Void Ortega.Share.Master.Data.BattleSkillNameSettingMB::.ctor()

 ---> System.Exception: Basic block has to end with unconditional control flow. 
{
	Block_0:
	call:void(object::.ctor, ldloc:BattleSkillNameSettingMB[exp:object](this))
	stloc:int32(var_0_07, ldc.i4:int32(0))
	stfld:int64(MasterBookBase::Id, ldloc:BattleSkillNameSettingMB[exp:MasterBookBase](this), ldloc:int32[exp:int64](var_0_07))
	stfld:valuetype [mscorlib]System.Nullable`1<bool>(MasterBookBase::IsIgnore, ldloc:BattleSkillNameSettingMB[exp:MasterBookBase](this), ldloc:int32[exp:valuetype [mscorlib]System.Nullable`1<bool>](var_0_07))
	stfld:string(MasterBookBase::Memo, ldloc:BattleSkillNameSettingMB[exp:MasterBookBase](this), ldloc:int32[exp:string](var_0_07))
}

   at ICSharpCode.Decompiler.ILAst.ILAstOptimizer.FlattenBasicBlocks(ILNode node) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\ILAst\ILAstOptimizer.cs:line 1813
   at ICSharpCode.Decompiler.ILAst.ILAstOptimizer.Optimize(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider, StateMachineKind& stateMachineKind, MethodDef& inlinedMethod, AsyncMethodDebugInfo& asyncInfo, ILAstOptimizationStep abortBeforeStep) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\ILAst\ILAstOptimizer.cs:line 347
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.CreateMethodBody(IEnumerable`1 parameters, MethodDebugInfoBuilder& builder) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 123
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.CreateMethodBody(MethodDef methodDef, DecompilerContext context, AutoPropertyProvider autoPropertyProvider, IEnumerable`1 parameters, Boolean valueParameterIsKeyword, StringBuilder sb, MethodDebugInfoBuilder& stmtsBuilder) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 99
   --- End of inner exception stack trace ---
   at ICSharpCode.Decompiler.Ast.AstMethodBodyBuilder.CreateMethodBody(MethodDef methodDef, DecompilerContext context, AutoPropertyProvider autoPropertyProvider, IEnumerable`1 parameters, Boolean valueParameterIsKeyword, StringBuilder sb, MethodDebugInfoBuilder& stmtsBuilder) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstMethodBodyBuilder.cs:line 99
   at ICSharpCode.Decompiler.Ast.AstBuilder.AddMethodBody(EntityDeclaration methodNode, EntityDeclaration& updatedNode, MethodDef method, IEnumerable`1 parameters, Boolean valueParameterIsKeyword, MethodKind methodKind) in D:\a\dnSpy\dnSpy\Extensions\ILSpy.Decompiler\ICSharpCode.Decompiler\ICSharpCode.Decompiler\Ast\AstBuilder.cs:line 1627
*/;
		}

		public int GetNewLineIndex(LanguageType languageType)
		{
			if (languageType == LanguageType.jaJP)
			{
				return this.NewLineIndexTW;
			}
			return this.NewLineIndexUS;
		}
	}
}