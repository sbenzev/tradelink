#pragma once
#include "ObserverApi.h"
#include "BusinessApi.h"
#include "ExtFrame.h"


unsigned int TIFId(CString name);

class TLStock : public Observer
	//we derive this object from Obsererver to be able to get info about dynamic changes of the stock
    //every Observer must have function virtual void Process(const Message* message, Observable* from, const Message* additionalInfo); which will be called when a stock update is received from the server.
{
public:
    TLStock(const char* symbol, bool load = false);

    virtual ~TLStock();


    void Load();
    const StockBase* GetStockHandle() const{return m_stockHandle;}
    bool isLoaded() const{return m_stockHandle != NULL && B_IsStockLoaded(m_stockHandle);}
    const std::string& GetSymbol() const{return m_symbol;}

    Observable* GetLevel1(){return m_level1;}
    Observable* GetLevel2(){return m_level2;}
    Observable* GetPrints(){return m_prints;}

	void Clear();
protected:
    virtual void Process(const Message* message, Observable* from, const Message* additionalInfo);
    std::string m_symbol;
    const StockBase* m_stockHandle;
    Observable* m_level1;
    Observable* m_level2;
    Observable* m_prints;
	Observable* m_account;


};

