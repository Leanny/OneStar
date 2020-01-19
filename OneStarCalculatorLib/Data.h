#pragma once
#include "Type.h"

extern _u64 g_TempMatrix[256];
extern _u64 g_InputMatrix[64];
extern _u64 g_ConstantTermVector;
extern _u64 g_Coefficient[64];
extern _u64 g_AnswerFlag[64];
extern _u64 g_CoefficientData[0x4000];
extern _u64 g_SearchPattern[0x4000];
extern int g_FreeBit[64];
extern int g_FreeId[64];

void InitializeTransformationMatrix();
void ProceedTransformationMatrix();
_u64 GetMatrixMultiplier(int index);
short GetMatrixConst(int index);

void CalculateInverseMatrix(int length);
void CalculateCoefficientData(int length);
