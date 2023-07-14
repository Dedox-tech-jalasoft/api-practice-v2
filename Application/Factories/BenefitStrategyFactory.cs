﻿using InsuranceAPIv2.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPIv2.Application.Factories
{
    public class BenefitStrategyFactory : IBenefitStrategyFactory
    {
        private readonly IEnumerable<IBenefitStrategy> benefitStrategies;

        public BenefitStrategyFactory(IEnumerable<IBenefitStrategy> benefitStrategies)
        {
            this.benefitStrategies = benefitStrategies;
        }

        public IBenefitStrategy GetBenefitStrategy(int carrierId)
        {
            IBenefitStrategy? benefitStrategy = benefitStrategies
                .FirstOrDefault(strategy => strategy.SupportedCarrier == carrierId);

            if (benefitStrategy == null)
            {
                throw new NotSupportedException($"Not supported strategy found for carrierId {carrierId}");
            }

            return benefitStrategy;
        }
    }
}